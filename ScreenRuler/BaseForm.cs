using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenRuler
{
    [DesignerCategory("")]
    public class BaseForm : Form
    {
        private const int MINIMAL_LENGTH = 150;

        public BaseForm()
        {
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
        }

        #region Sizing Restriction

        private FormResizeMode resizeMode;
        private int cachedWidth, cachedHeight;

        public FormResizeMode ResizeMode
        {
            get => resizeMode;
            set
            {
                applyResizeMode(value);
            }
        }

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
                    this.MaximumSize = new Size(int.MaxValue, RulerPainter.RULER_WIDTH);
                    if (wRest) this.Width = cachedWidth;
                    break;
                case FormResizeMode.Vertical:
                    this.MaximumSize = new Size(RulerPainter.RULER_WIDTH, int.MaxValue);
                    if (hRest) this.Height = cachedHeight;
                    break;
                case FormResizeMode.TwoDimensional:
                    this.MaximumSize = Size.Empty;
                    if (wRest) this.Width = cachedWidth;
                    if (hRest) this.Height = cachedHeight;
                    break;
            }
            CheckOutOfBounds();
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
