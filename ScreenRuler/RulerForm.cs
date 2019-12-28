using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using ScreenRuler.Units;
using Bluegrams.Application;
using Bluegrams.Application.WinForms;
using ScreenRuler.Properties;

namespace ScreenRuler
{
    public partial class RulerForm : Form
    {
        private WinFormsWindowManager manager;
        private WinFormsUpdateChecker updateChecker;
        private int mouseLine;

        public Settings Settings { get; set; }
        public bool Vertical { get { return Settings.Vertical; } }
        public LinkedList<int> CustomLines { get; set; }
        /// <summary>
        /// Gets/ sets the length of the ruler.
        /// </summary>
        public int RulerLength
        {
            get { return Vertical ? this.Height : this.Width; }
            set
            {
                if (Vertical) this.Height = value;
                else this.Width = value;
            }
        }

        public RulerForm()
        {
            Settings = new Settings();
            manager = new WinFormsWindowManager(this) { AlwaysTrackResize = true };
            // Name all the properties we want to have persisted
            manager.ManageDefault();
            manager.Manage(nameof(Settings), nameof(TopMost));
            manager.Manage(nameof(CustomLines), SettingsSerializeAs.Binary);
            manager.Manage(nameof(Opacity), defaultValue: 1);
            manager.Initialize();
            InitializeComponent();
            updateChecker = new WinFormsUpdateChecker(Program.UPDATE_URL, this, Program.UPDATE_MODE);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            this.TopMost = true;
            CustomLines = new LinkedList<int>();
            this.MouseWheel += RulerForm_MouseWheel;
            rulerToolTip.SetToolTip(this, RulerLength.ToString());
        }

        private UnitConverter getUnitConverter()
        {
            var screenRect = Screen.FromControl(this).Bounds;
            var screenSize = Settings.Vertical ? screenRect.Height : screenRect.Width;
            return new UnitConverter(Settings.MeasuringUnit, screenSize, Settings.MonitorDpi);
        }

        private void RulerForm_Load(object sender, EventArgs e)
        {
            // Set some items of the context menu
            foreach (Enum item in Enum.GetValues(typeof(MeasuringUnit)))
            {
                comUnits.Items.Add(item.GetDescription());
            }
            // Reset the currently selected theme to avoid inconsistencies
            // caused by manual edits in the settings file.
            Settings.SelectedTheme = Settings.SelectedTheme;
            switch (this.Opacity*100)
            {
                case 100:
                    conHigh.Checked = true;
                    break;
                case 80:
                    conDefault.Checked = true;
                    break;
                case 60:
                    conLow.Checked = true;
                    break;
                case 40:
                    conVeryLow.Checked = true;
                    break;
            }
            // Check for updates
            updateChecker.CheckForUpdates();
        }

        #region Input Events
        //Message result codes of WndProc that trigger resizing:
        // HTLEFT = 10 -> in left resize area 
        // HTRIGHT = 11 -> in right resize area
        // HTTOP = 12 -> in upper resize area
        // HTBOTTOM = 15 -> in lower resize area
        private int FirstGrip { get { return Vertical ? 12 : 10; } }
        private int SecondGrip { get { return Vertical ? 15 : 11; } }

        // Use Windows messages to handle resizing of the ruler at the edges
        // and moving of the cursor marker.
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84) //WM_NCHITTEST (sent for all mouse events)
            {
                // Get mouse position and convert to app coordinates
                Point pos = Cursor.Position;
                pos = this.PointToClient(pos);
                int rpos = Vertical ? pos.Y : pos.X;
                // Move mouse marker
                mouseLine = rpos;
                this.Invalidate();
                // Check if inside grip area (5 pixels next to border)
                if (rpos <= 5)
                {
                    m.Result = (IntPtr)FirstGrip;
                    return;
                }
                else if (rpos >= (Vertical ? this.ClientSize.Height : this.ClientSize.Width) - 5)
                {
                    m.Result = (IntPtr)SecondGrip;
                    return;
                }
            }
            // Pass return message down to base class
            base.WndProc(ref m);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    conExit.PerformClick();
                    break;
                case Keys.Z:
                    conMeasure.PerformClick();
                    break;
                case Keys.S:
                    conTopmost.PerformClick();
                    break;
                case Keys.V:
                    conVertical.PerformClick();
                    break;
                case Keys.M:
                    conMarkCenter.PerformClick();
                    break;
                case Keys.T:
                    conMarkThirds.PerformClick();
                    break;
                case Keys.P:
                    conMarkMouse.PerformClick();
                    break;
                case Keys.Delete:
                    conClearCustomMarker.PerformClick();
                    break;
                case Keys.C:
                    if (e.Control)
                    {
                        // copy size
                        Clipboard.SetText(RulerLength.ToString());
                    }
                    else
                    {
                        // clear first custom marker
                        if (CustomLines.Count > 0)
                        {
                            CustomLines.RemoveFirst();
                            this.Invalidate();
                        }
                    }
                    break;
                case Keys.L:
                    setMarkerToList(RulerLength);
                    this.Invalidate();
                    break;
                case Keys.F1:
                    conHelp.PerformClick();
                    break;
                default:
                    if (e.Control) resizeKeyDown(e);
                    else if (e.Alt) dockKeyDown(e);
                    else moveKeyDown(e);
                    break;
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Handles moving key events.
        /// </summary>
        private void moveKeyDown(KeyEventArgs e)
        {
            int step = e.Shift ? Settings.MediumStep : 1;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    this.Left -= step;
                    break;
                case Keys.Right:
                    this.Left += step;
                    break;
                case Keys.Up:
                    this.Top -= step;
                    break;
                case Keys.Down:
                    this.Top += step;
                    break;
            }
        }

        /// <summary>
        /// Handles resizing key events.
        /// </summary>
        private void resizeKeyDown(KeyEventArgs e)
        {
            int step = e.Shift ? Settings.MediumStep : 1;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (!Vertical) this.Width -= step;
                    break;
                case Keys.Right:
                    if (!Vertical) this.Width += step;
                    break;
                case Keys.Up:
                    if (Vertical) this.Height -= step;
                    break;
                case Keys.Down:
                    if (Vertical) this.Height += step;
                    break;
            }
        }

        /// <summary>
        /// Handles key events for docking to borders.
        private void dockKeyDown(KeyEventArgs e)
        {
            Screen screen = Screen.FromControl(this);
            switch(e.KeyCode)
            {
                case Keys.Left:
                    this.Left = screen.WorkingArea.Left;
                    break;
                case Keys.Right:
                    this.Left = screen.WorkingArea.Right - this.Width;
                    break;
                case Keys.Up:
                    this.Top = screen.WorkingArea.Top;
                    break;
                case Keys.Down:
                    this.Top = screen.WorkingArea.Bottom - this.Height;
                    break;
            }
        }


        private void RulerForm_MouseWheel(object sender, MouseEventArgs e)
        {
            // Resize according to mouse scroll direction.
            var amount = Math.Sign(e.Delta);
            if (ModifierKeys.HasFlag(Keys.Shift))
                amount *= Settings.LargeStep;
            RulerLength += amount;
        }

        private void RulerForm_MouseClick(object sender, MouseEventArgs e)
        {
            var position = Vertical ? e.Y : e.X;
            var line = CustomLines.Where((val) => Math.Abs(position - val) <= 2).FirstOrDefault();
            if (line != default(int))
            {
                CustomLineForm lineForm = new CustomLineForm(line,
                    getUnitConverter(), Settings.Theme);
                if (lineForm.ShowDialog(this) == DialogResult.OK)
                {
                    CustomLines.Remove(line);
                    this.Invalidate();
                }
            }
        }

        private void RulerForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Add a marker at the cursor position.
            setMarkerToList(Vertical ? e.Y : e.X);
        }

        private void setMarkerToList(int pos)
        {
            // By default a single new marker is set, replacing the old one.
            if (!Settings.MultiMarking) CustomLines.Clear();
            CustomLines.AddLast(pos);
        }
        #endregion

        #region Draw Components
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Settings.Theme.Background);
            var painter = new RulerPainter(this, Settings);
            painter.Paint(e.Graphics);
            painter.PaintMarkers(e.Graphics, mouseLine, CustomLines);
            base.OnPaint(e);
        }
        #endregion

        #region Context Menu
        // Load current context menu state
        private void contxtMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            conVertical.Checked = Vertical;
            conMarkCenter.Checked = Settings.ShowCenterLine;
            conMarkThirds.Checked = Settings.ShowThirdLines;
            conTopmost.Checked = this.TopMost;
            conMarkMouse.Checked = Settings.ShowMouseLine;
            conOffsetLength.Checked = Settings.ShowOffsetLengthLabels;
            conMultiMarking.Checked = !Settings.MultiMarking;
            comUnits.SelectedIndex = (int)Settings.MeasuringUnit;
        }

        private void conMeasure_Click(object sender, EventArgs e)
        {
            var overlay = new OverlayForm();
            overlay.TopMost = this.TopMost;
            if (overlay.ShowDialog() == DialogResult.OK)
            {
                this.Location = overlay.WindowSelection.Location;
                if (Vertical) this.Height = overlay.WindowSelection.Height;
                else this.Width = overlay.WindowSelection.Width;
                checkOutOfBorders();
                Settings.ShowOffsetLengthLabels = true;
            }
        }

        private void checkOutOfBorders()
        {
            var screenRec = Screen.FromRectangle(Bounds).WorkingArea;
            if (!screenRec.IntersectsWith(Bounds))
            {
                Point newLocation = Location;
                if (Location.X < screenRec.X)
                    newLocation.X = screenRec.X;
                else if (Location.X > screenRec.Right)
                    newLocation.X = screenRec.Right - Width;
                if (Location.Y < screenRec.Y)
                    newLocation.Y = screenRec.Y;
                else if (Location.Y >= screenRec.Bottom)
                    newLocation.Y = screenRec.Bottom - Height;
                Location = newLocation;
            }
        }

        private void conMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.MeasuringUnit = (MeasuringUnit)comUnits.SelectedIndex;
            this.Invalidate();
        }

        private void conMarkMouse_Click(object sender, EventArgs e)
        {
            Settings.ShowMouseLine = !Settings.ShowMouseLine;
            this.Invalidate();
        }

        private void conMarkCenter_Click(object sender, EventArgs e)
        {
            Settings.ShowCenterLine = !Settings.ShowCenterLine;
            this.Invalidate();
        }

        private void conMarkThirds_Click(object sender, EventArgs e)
        {
            Settings.ShowThirdLines = !Settings.ShowThirdLines;
            this.Invalidate();
        }

        private void conOffsetLength_Click(object sender, EventArgs e)
        {
            Settings.ShowOffsetLengthLabels = !Settings.ShowOffsetLengthLabels;
            this.Invalidate();
        }

        private void conMultiMarking_Click(object sender, EventArgs e)
        {
            Settings.MultiMarking = !Settings.MultiMarking;
            if (CustomLines.Count > 0) setMarkerToList(CustomLines.Last.Value);
            this.Invalidate();
        }

        private void conClearCustomMarker_Click(object sender, EventArgs e)
        {
            CustomLines.Clear();
            this.Invalidate();
        }

        private void conTopmost_Click(object sender, EventArgs e) => TopMost = !TopMost;

        private void conVertical_Click(object sender, EventArgs e)
        {
            Settings.Vertical = !Settings.Vertical;
            changeVertical();
        }

        private void changeVertical()
        {
            this.Size = new Size(this.Height, this.Width);
            Rectangle windowRect = new Rectangle(this.Location, this.Size);
            Rectangle screenRect = Screen.FromRectangle(windowRect).WorkingArea;
            // If the ruler got out of the visible area, move it back in
            if (!screenRect.IntersectsWith(windowRect))
            {
                if (this.Left < screenRect.Left)
                    this.Left = screenRect.Left;
                else if (this.Left > screenRect.Right)
                    this.Left = screenRect.Right - this.Width;
                if (this.Top < screenRect.Top)
                    this.Top = screenRect.Top;
                else if (this.Top > screenRect.Bottom)
                    this.Top = screenRect.Bottom - this.Height;
            }
        }

        private void changeOpacity(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem it in conOpacity.DropDownItems)
                it.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
            int opacity = int.Parse((String)((ToolStripMenuItem)sender).Tag);
            this.Opacity = (double)opacity / 100;
        }

        private void conLength_Click(object sender, EventArgs e)
        {
            SetSizeForm sizeForm = new SetSizeForm(RulerLength, Settings);
            sizeForm.TopMost = this.TopMost;
            if (sizeForm.ShowDialog(this) == DialogResult.OK)
            {
                this.RulerLength = sizeForm.RulerLength;
            }
        }

        private void setToolTip()
        {
            // Tool tip
            if (Settings.ShowToolTip)
            {
                rulerToolTip.SetToolTip(this,
                    String.Format(Resources.ToolTipText, RulerLength, $"{Left}, {Top}"));
            }
            else rulerToolTip.SetToolTip(this, String.Empty);
        }

        private void RulerForm_Move(object sender, EventArgs e)
        {
            setToolTip();
        }

        private void RulerForm_SizeChanged(object sender, EventArgs e)
        {
            setToolTip();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(Settings);
            if (settingsForm.ShowDialog(this) == DialogResult.OK)
            {
                this.Invalidate();
            }
        }

        private void conHelp_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.ShowDialog(this);
        }

        private void conAbout_Click(object sender, EventArgs e)
        {
            var resMan = new System.Resources.ResourceManager(this.GetType());
            var img = ((Icon)resMan.GetObject("$this.Icon")).ToBitmap();
            AboutForm aboutForm = new AboutForm(img);
            aboutForm.UpdateChecker = updateChecker;
            aboutForm.ShowDialog(this);
        }

        private void conExit_Click(object sender, EventArgs e) => Close();
        #endregion

        // Handles dragging of the ruler
        #region Form Dragging
        private bool mouseDown;
        private Point mouseLoc;

        private void RulerForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseLoc = e.Location;
        }

        private void RulerForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(this.Location.X - mouseLoc.X + e.X, this.Location.Y - mouseLoc.Y + e.Y);
            }
        }

        private void RulerForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        #endregion
    }
}
