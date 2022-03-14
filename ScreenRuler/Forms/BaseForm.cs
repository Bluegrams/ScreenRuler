using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenRuler
{
    public enum SnapMode
    {
        None = 0,
        SnapToEdges = 1,
        LimitToEdges = 2
    }

    public class ResizeModeEventArgs : EventArgs
    {
        public FormResizeMode NewResizeMode { get; }

        public ResizeModeEventArgs(FormResizeMode newResizeMode)
        {
            this.NewResizeMode = newResizeMode;
        }
    }

    [DesignerCategory("")]
    public class BaseForm : Form
    {
        private const int MINIMAL_LENGTH = 150;

        /// <summary>
        /// Specifies the snapping behavior of this window.
        /// </summary>
        public SnapMode SnapMode { get; set; }

        /// <summary>
        /// Gets the snap margin of the form.
        /// Snapping to bounds is turned off for values lower than 1.
        /// </summary>
        public int SnapMargin { get; }

        public BaseForm() : this(SnapMode.None, 10) { }

        public BaseForm(SnapMode snapMode, int snapMargin)
        {
            this.SnapMode = snapMode;
            this.SnapMargin = snapMargin;
            if (snapMargin > 0)
                this.LocationChanged += baseForm_LocationChanged;
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
        }

        /// <summary>
        /// Snaps the window to screen bounds when it's near.
        /// </summary>
        private void baseForm_LocationChanged(object sender, EventArgs e)
        {
            if (!this.Visible || SnapMode == SnapMode.None) return;
            Screen screen = Screen.FromControl(this);
            Point upperLeft = screen.WorkingArea.Location;
            Point lowerRight = new Point(screen.WorkingArea.Right, screen.WorkingArea.Bottom);
            if (SnapMode == SnapMode.SnapToEdges)
            {
                if (Math.Abs(this.Left - upperLeft.X) <= SnapMargin)
                    this.Left = upperLeft.X;
                if (Math.Abs(this.Top - upperLeft.Y) <= SnapMargin)
                    this.Top = upperLeft.Y;
                if (Math.Abs(this.Right - lowerRight.X) <= SnapMargin)
                    this.Left = lowerRight.X - this.Width;
                if (Math.Abs(this.Bottom - lowerRight.Y) <= SnapMargin)
                    this.Top = lowerRight.Y - this.Height;
            }
            else if (SnapMode == SnapMode.LimitToEdges)
            {
                if (this.Left < upperLeft.X)
                    this.Left = upperLeft.X;
                if (this.Top < upperLeft.Y)
                    this.Top = upperLeft.Y;
                // The size checks are to prevent flackering when the ruler size exceeds the screen size
                if (this.Right > lowerRight.X && this.Width <= screen.WorkingArea.Width)
                    this.Left = lowerRight.X - this.Width;
                if (this.Bottom > lowerRight.Y && this.Height <= screen.WorkingArea.Height)
                    this.Top = lowerRight.Y - this.Height;
            }
        }

        #region Sizing Restriction

        private int restrictSize;
        private FormResizeMode resizeMode;
        private int cachedWidth, cachedHeight;

        public int RestrictSize
        {
            get => restrictSize;
        }

        public void SetRestrictSize(int value, bool useScaleFactor = true)
        {
            System.Diagnostics.Debug.WriteLine(this.DeviceDpi);
            if (useScaleFactor)
            {
                float scaleFactor = this.DeviceDpi / 96.0f;
                restrictSize = (int)(value * scaleFactor);
            }
            else
            {
                restrictSize = value;
            }
            applyResizeMode(ResizeMode);
        }

        public FormResizeMode ResizeMode
        {
            get => resizeMode;
            set
            {
                applyResizeMode(value);
            }
        }

        public event EventHandler<ResizeModeEventArgs> ResizeModeChanged;

        private void applyResizeMode(FormResizeMode resizeMode)
        {
            this.resizeMode = resizeMode;
            bool wRest = this.MaximumSize.Width < int.MaxValue && !this.MaximumSize.IsEmpty;
            bool hRest = this.MaximumSize.Height < int.MaxValue && !this.MaximumSize.IsEmpty;
            if (!wRest) cachedWidth = Math.Max(MINIMAL_LENGTH, this.Width);
            if (!hRest) cachedHeight = Math.Max(MINIMAL_LENGTH, this.Height);
            switch (resizeMode)
            {
                case FormResizeMode.Horizontal:
                    this.MaximumSize = new Size(int.MaxValue, RestrictSize);
                    this.Height = RestrictSize;
                    if (wRest) this.Width = cachedWidth;
                    break;
                case FormResizeMode.Vertical:
                    this.MaximumSize = new Size(RestrictSize, int.MaxValue);
                    this.Width = RestrictSize;
                    if (hRest) this.Height = cachedHeight;
                    break;
                case FormResizeMode.TwoDimensional:
                    this.MaximumSize = Size.Empty;
                    if (wRest) this.Width = cachedWidth;
                    if (hRest) this.Height = cachedHeight;
                    break;
            }
            CheckOutOfBounds();
            ResizeModeChanged?.Invoke(this, new ResizeModeEventArgs(resizeMode));
            Invalidate();
        }

        protected void CheckOutOfBounds()
        {
            Rectangle screenRect = Screen.FromRectangle(Bounds).WorkingArea;
            // If the ruler got out of the visible area, move it back in
            if (!screenRect.IntersectsWith(Bounds))
            {
                Point newLocation = Location;
                if (Location.X < screenRect.X)
                    newLocation.X = screenRect.X;
                else if (Location.X > screenRect.Right)
                    newLocation.X = screenRect.Right - Width;
                if (Location.Y < screenRect.Y)
                    newLocation.Y = screenRect.Y;
                else if (Location.Y >= screenRect.Bottom)
                    newLocation.Y = screenRect.Bottom - Height;
                Location = newLocation;
            }
        }

        #endregion

        // Handles dragging of the form
        #region Form Dragging

        private bool mouseDown;
        private Point mouseLoc;

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseLoc = e.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(this.Location.X - mouseLoc.X + e.X, this.Location.Y - mouseLoc.Y + e.Y);
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        #endregion
    }
}
