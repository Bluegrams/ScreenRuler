using System;
using System.Drawing;
using System.Windows.Forms;
using Bluegrams.Application;
using Bluegrams.Application.WinForms;
using ScreenRuler.Properties;
using System.ComponentModel;
using ScreenRuler.Colors;
using ScreenRuler.Units;
using System.Drawing.Drawing2D;

namespace ScreenRuler
{
    [DesignerCategory("Form")]
    public partial class RulerForm : BaseForm
    {
        private Options options;
        private WinFormsWindowManager manager;
        private WinFormsUpdateChecker updateChecker;
        private MouseTracker mouseTracker;
        private RulerPainter painter;
        private MarkerListForm markerListForm;

        public Settings Settings { get; set; }
        public MarkerCollection CustomMarkers { get; set; }

        public RulerForm() : this(null) { }

        public RulerForm(Options options)
        {
            this.options = options;
            Settings = new Settings();
            CustomMarkers = new MarkerCollection();
            manager = new WinFormsWindowManager(this) { AlwaysTrackResize = true };
            // Name all the properties we want to have persisted
            manager.ManageDefault();
            manager.Manage(nameof(Settings), nameof(TopMost), nameof(CustomMarkers));
            manager.Manage(nameof(ResizeMode), defaultValue: FormResizeMode.Horizontal);
            manager.Manage(nameof(Opacity), defaultValue: 1);
            manager.Initialize();
            InitializeComponent();
            updateChecker = new WinFormsUpdateChecker(Program.UPDATE_URL, this, Program.UPDATE_MODE);
            mouseTracker = new MouseTracker(this);
            mouseTracker.Tick += mouseTracker_Tick;
            painter = new RulerPainter(this);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.TopMost = true;
            this.MouseWheel += RulerForm_MouseWheel;
            this.DpiChanged += RulerForm_DpiChanged;
        }

        private UnitConverter getUnitConverter() => UnitConverter.FromSettings(this, Settings);

        private void RulerForm_Load(object sender, EventArgs e)
        {
            // Set some items of the context menu
            foreach (Enum item in Enum.GetValues(typeof(MeasuringUnit)))
            {
                comUnits.Items.Add(item.GetDescription());
            }
            foreach (Enum item in Enum.GetValues(typeof(HypotenuseMode)))
            {
                conHypotenuse.DropDownItems.Add(
                    new ToolStripMenuItem(item.GetDescription(), null, conHypotenuse_Click)
                    {
                        Tag = item,
                        Checked = Settings.HypotenuseMode == (HypotenuseMode)item
                    }
                );
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
            // apply other loaded settings
            applySettings();
            applyCLIOptions();
            // Check for updates
            updateChecker.CheckForUpdates(UpdateNotifyMode.Auto);
            // Start tracking mouse
            mouseTracker.Start();
            // Set the minimum size
            this.SetRestrictSize(Settings.SlimMode ? RulerPainter.RULER_WIDTH_SLIM : RulerPainter.RULER_WIDTH_WIDE);
        }

        // a helper method to be called after settings values have changed
        private void applySettings()
        {
            // Set the marker limit
            CustomMarkers.Limit = Settings.MultiMarking ? int.MaxValue : 1;
            // Show notify icon or task bar entry based on settings
            if (Settings.UseNotifyIcon)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }
            else if (!this.ShowInTaskbar)
            {
                this.ShowInTaskbar = true;
                notifyIcon.Visible = false;
            }
            this.SnapMode = Settings.SnapToScreenEdges ? SnapMode.LimitToEdges : SnapMode.None;
        }

        private void applyCLIOptions()
        {
            if (options.X.HasValue)
                this.Left = options.X.Value;
            if (options.Y.HasValue)
                this.Top = options.Y.Value;
            if (options.Width.HasValue && options.Height.HasValue)
            {
                this.ResizeMode = FormResizeMode.TwoDimensional;
                this.Width = options.Width.Value;
                this.Height = options.Height.Value;
            }
            else if (options.Width.HasValue)
            {
                this.ResizeMode = FormResizeMode.Horizontal;
                this.Width = options.Width.Value;
            }
            else if (options.Height.HasValue)
            {
                this.ResizeMode = FormResizeMode.Vertical;
                this.Height = options.Height.Value;
            }
            else
            {
                Rectangle windowRect = Rectangle.Empty;
                if (options.WindowHandle != null)
                    windowRect = WinApi.GetWindowRectangle((IntPtr)options.WindowHandle);
                else if (options.WindowTitle != null)
                    windowRect = WinApi.GetWindowRectangle(options.WindowTitle);

                if (windowRect != Rectangle.Empty)
                    measureRectangle(windowRect);
            }
        }
        private void RulerForm_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("UI DPI changed: " + e.DeviceDpiNew);
            this.SetRestrictSize(Settings.SlimMode ? RulerPainter.RULER_WIDTH_SLIM : RulerPainter.RULER_WIDTH_WIDE);
        }


        private void RulerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mouseTracker.Stop();
        }

        #region Input Events
        //Message result codes of WndProc that trigger resizing:
        // HTLEFT = 10 -> in left resize area 
        // HTRIGHT = 11 -> in right resize area
        // HTTOP = 12 -> in upper resize area
        // HTBOTTOM = 15 -> in lower resize area
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTBOTTOM = 15;

        private const int GRIP_OFFSET = 5;

        // Use Windows messages to handle resizing of the ruler at the edges
        // and moving of the cursor marker.
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                //WM_NCHITTEST (sent for all mouse events)
                case 0x84:
                    // Get mouse position and convert to app coordinates
                    Point pos = Cursor.Position;
                    pos = this.PointToClient(pos);
                    // Check if inside grip area (5 pixels next to border)
                    if (ResizeMode.HasFlag(FormResizeMode.Horizontal))
                    {
                        if (pos.X <= GRIP_OFFSET)
                        {
                            m.Result = (IntPtr)HTLEFT;
                            return;
                        }
                        else if (pos.X >= this.ClientSize.Width - GRIP_OFFSET)
                        {
                            m.Result = (IntPtr)HTRIGHT;
                            return;
                        }
                    }
                    if (ResizeMode.HasFlag(FormResizeMode.Vertical))
                    { 
                        if (pos.Y <= GRIP_OFFSET)
                        {
                            m.Result = (IntPtr)HTTOP;
                            return;
                        }
                        else if (pos.Y >= this.ClientSize.Height - GRIP_OFFSET)
                        {
                            m.Result = (IntPtr)HTBOTTOM;
                            return;
                        }
                    }
                    break;
            }
            // Pass return message down to base class
            base.WndProc(ref m);
        }

        private void mouseTracker_Tick(object sender, EventArgs e)
        {
            if (Settings.FollowMousePointer)
            {
                int offsetX, offsetY;
                if (Settings.FollowMousePointerCenter)
                {
                    offsetX = this.Size.Width / 2;
                    offsetY = ResizeMode == FormResizeMode.Vertical ? this.Size.Height / 2 : this.RestrictSize / 2;
                }
                else
                {
                    offsetX = 10;
                    offsetY = 10;
                }
                this.Location = new Point(Cursor.Position.X - offsetX, Cursor.Position.Y - offsetY);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    toggleRulerMode();
                    break;
                case Keys.F:
                    if (e.Shift) conFlipVertically.PerformClick();
                    else conFlipHorizontally.PerformClick();
                    break;
                case Keys.J:
                    conSlimMode.PerformClick();
                    break;
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
                    toggleVertical();
                    break;
                case Keys.M:
                    conMarkCenter.PerformClick();
                    break;
                case Keys.T:
                    if (e.Control)
                    {
                        if (Settings.SelectedTheme == ThemeOption.Light)
                        {
                            Settings.SelectedTheme = ThemeOption.Dark;
                        }
                        else
                        {
                            Settings.SelectedTheme = ThemeOption.Light;
                        }
                    }
                    else
                    {
                        conMarkThirds.PerformClick();
                    }
                    break;
                case Keys.G:
                    conMarkGolden.PerformClick();
                    break;
                case Keys.P:
                    conMarkMouse.PerformClick();
                    break;
                case Keys.H:
                    toggleHypotenuseMode();
                    break;
                case Keys.Delete:
                    conClearCustomMarker.PerformClick();
                    break;
                case Keys.C:
                    if (e.Control)
                    {
                        // copy size
                        Clipboard.SetText($"{Width}, {Height}");
                    }
                    else
                    {
                        // clear first custom marker
                        if (CustomMarkers.Markers.Count > 0)
                        {
                            CustomMarkers.RemoveFirstMarker();
                            this.Invalidate();
                        }
                    }
                    break;
                case Keys.X:
                    addMarkersAtCurrentPosition();
                    break;
                case Keys.L:
                    CustomMarkers.AddMarker((Point)this.Size, RestrictSize);
                    this.Invalidate();
                    break;
                case Keys.W:
                    conFollowMousePointer.PerformClick();
                    break;
                case Keys.Oemplus:
                    if (e.Control) changeOpacity(true);
                    break;
                case Keys.OemMinus:
                    if (e.Control) changeOpacity(false);
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
            int step = e.Shift ? Settings.MediumStep : Settings.SmallStep;
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
            int step = e.Shift ? Settings.MediumStep : Settings.SmallStep;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    this.Width -= step;
                    break;
                case Keys.Right:
                    this.Width += step;
                    break;
                case Keys.Up:
                    this.Height -= step;
                    break;
                case Keys.Down:
                    this.Height += step;
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
            else amount *= Settings.SmallStep;
            // Add to width or height according to current mode and mouse location
            if (ResizeMode == FormResizeMode.Horizontal)
            {
                Width += amount;
            }
            else if (ResizeMode == FormResizeMode.Vertical)
            {
                Height += amount;
            }
            else
            {
                if (e.Y > this.RestrictSize)
                    Height += amount;
                else Width += amount;
            }
        }

        private void RulerForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Settings.HideRulerScale)
            {
                using (Matrix matrix = painter.GetTransformationMatrix())
                {
                    Point[] points = new[] { e.Location };
                    matrix.TransformPoints(points);
                    Marker marker = CustomMarkers.GetMarker(points[0], RestrictSize);
                    if (marker != Marker.Default)
                    {
                        CustomLineForm lineForm = new CustomLineForm(marker,
                            getUnitConverter(), Settings.Theme);
                        if (lineForm.ShowDialog(this) == DialogResult.OK)
                        {
                            CustomMarkers.RemoveMarker(marker);
                            this.Invalidate();
                        }
                    }
                }
            }
        }

        private void RulerForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            using (Matrix matrix = painter.GetTransformationMatrix())
            {
                Point[] points = new[] { e.Location };
                matrix.TransformPoints(points);
                // Add a marker at the cursor position.
                CustomMarkers.AddMarker(points[0], RestrictSize, ResizeMode == FormResizeMode.Vertical);
            }
        }

        private void addMarkersAtCurrentPosition()
        {
            Point position = Cursor.Position;
            int horizontal = position.X - this.Left;
            int vertical = position.Y - this.Top;
            if (this.ResizeMode == FormResizeMode.Horizontal)
            {
                CustomMarkers.AddMarker(new Marker(horizontal, false));
            }
            else if (this.ResizeMode == FormResizeMode.Vertical)
            {
                CustomMarkers.AddMarker(new Marker(vertical, true));
            }
            else
            {
                CustomMarkers.AddMarker(new Marker(horizontal, false));
                CustomMarkers.AddMarker(new Marker(vertical, true));
            }
        }
        #endregion

        #region Draw Components
        protected override void OnPaint(PaintEventArgs e)
        {
            BufferedGraphics buffer;
            buffer = BufferedGraphicsManager.Current.Allocate(e.Graphics, e.ClipRectangle);
            // clear the graphics first
            buffer.Graphics.FillRectangle(new SolidBrush(TransparencyKey), e.ClipRectangle);
            // paint the ruler into buffer
            painter.Update(buffer.Graphics, Settings, ResizeMode);
            painter.PaintRuler();
            painter.PaintMarkers(CustomMarkers, mouseTracker.Position);
            // paint buffer onto screen
            buffer.Render();
            buffer.Dispose();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            /* Draw two transparent rectangles at the borders not occupied by the ruler itself.
             * This should prevent (most of) the flickering at these borders.
             */
            bool scaleOnTop = !Settings.FlippedY;
            bool scaleOnLeft = !Settings.FlippedX;
            // The maximum width/ or height of the transparent rectangles.
            int maxRectWidth = this.RestrictSize / 2;
            using (Brush brush = new SolidBrush(TransparencyKey))
            {
                // --- Horizontal rectangle ---
                // Draw at lower or upper border?
                int xCoordH = scaleOnLeft ? RestrictSize : 0;
                int yCoordH = scaleOnTop ? Math.Max(RestrictSize, Height - maxRectWidth) : 0;
                e.Graphics.FillRectangle(
                    brush,
                    new Rectangle(
                        xCoordH, yCoordH,
                        Width - RestrictSize, Math.Min(Height - RestrictSize, maxRectWidth)
                    )
                );
                // --- Vertical rectangle ---
                // Draw at right or left border?
                int xCoordV = scaleOnLeft ? Math.Max(RestrictSize, Width - maxRectWidth) : 0;
                int yCoordV = scaleOnTop ? RestrictSize : 0;
                e.Graphics.FillRectangle(
                    brush,
                    new Rectangle(
                        xCoordV, yCoordV,
                        Math.Min(Width - RestrictSize, maxRectWidth), Height - RestrictSize
                    )
                );
            }
        }
        #endregion

        #region Ruler Mode
        private void toggleRulerMode()
        {
            ResizeMode = (FormResizeMode)(((int)ResizeMode + 1) % 3 + 1);
        }

        private void toggleVertical()
        {
            if (ResizeMode == FormResizeMode.Vertical)
            {
                int length = this.Height;
                ResizeMode = FormResizeMode.Horizontal;
                this.Width = length;
            }
            else
            {
                int length = this.Width;
                ResizeMode = FormResizeMode.Vertical;
                this.Height = length;
            }
        }

        private void toggleHypotenuseMode()
        {
            Settings.HypotenuseMode = (HypotenuseMode)(((int)Settings.HypotenuseMode + 1) % 3);
            foreach (ToolStripMenuItem it in conHypotenuse.DropDownItems)
            {
                it.Checked = (HypotenuseMode)it.Tag == Settings.HypotenuseMode;
            }
            this.Invalidate();
        }
        #endregion

        #region Context Menu
        // Load current context menu state
        private void contxtMenu_Opening(object sender, CancelEventArgs e)
        {
            conSlimMode.Checked = Settings.SlimMode;
            conTopmost.Checked = this.TopMost;
            comUnits.SelectedIndex = (int)Settings.MeasuringUnit;
            conFollowMousePointer.Checked = Settings.FollowMousePointer;
            setAppearanceCheckboxes();
            // Show ruler if it was minimized
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void setAppearanceCheckboxes()
        {
            conMarkCenter.Checked = Settings.ShowCenterLine;
            conMarkThirds.Checked = Settings.ShowThirdLines;
            conMarkGolden.Checked = Settings.ShowGoldenLine;
            conMarkMouse.Checked = Settings.ShowMouseLine;
            conOffsetLength.Checked = Settings.ShowOffsetLengthLabels;
            conHideRulerScale.Checked = Settings.HideRulerScale;
        }

        private void conRulerMode_DropDownOpening(object sender, EventArgs e)
        {
            conModeHorizontal.Checked = ResizeMode == FormResizeMode.Horizontal;
            conModeVertical.Checked = ResizeMode == FormResizeMode.Vertical;
            conModeTwoDimensional.Checked = ResizeMode == FormResizeMode.TwoDimensional;
        }

        private void conMeasure_Click(object sender, EventArgs e)
        {
            var overlay = new OverlayForm();
            overlay.TopMost = this.TopMost;
            if (overlay.ShowDialog() == DialogResult.OK)
            {
                measureRectangle(overlay.WindowSelection);
            }
        }

        private void measureRectangle(Rectangle rectangle)
        {
            this.ResizeMode = FormResizeMode.TwoDimensional;
            this.Location = rectangle.Location;
            this.Height = rectangle.Height;
            this.Width = rectangle.Width;
            this.CheckOutOfBounds();
            Settings.ShowOffsetLengthLabels = true;
        }

        private void conMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.MeasuringUnit = (MeasuringUnit)comUnits.SelectedIndex;
            Settings.InvokeChanged();
            this.Invalidate();
        }

        private void conFollowMousePointer_Click(object sender, EventArgs e)
        {
            Settings.FollowMousePointer = !Settings.FollowMousePointer;
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

        private void conMarkGolden_Click(object sender, EventArgs e)
        {
            Settings.ShowGoldenLine = !Settings.ShowGoldenLine;
            this.Invalidate();
        }

        private void conOffsetLength_Click(object sender, EventArgs e)
        {
            Settings.ShowOffsetLengthLabels = !Settings.ShowOffsetLengthLabels;
            this.Invalidate();
        }

        private void conHypotenuse_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem it in conHypotenuse.DropDownItems)
                it.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
            Settings.HypotenuseMode = (HypotenuseMode)((ToolStripMenuItem)sender).Tag;
            this.Invalidate();
        }

        private void conHideRulerScale_Click(object sender, EventArgs e)
        {
            Settings.HideRulerScale = !Settings.HideRulerScale;
            if (Settings.HideRulerScale)
            {
                Settings.ShowCenterLine = false;
                Settings.ShowThirdLines = false;
                Settings.ShowGoldenLine = false;
                Settings.ShowMouseLine = false;
                Settings.ShowOffsetLengthLabels = false;
                setAppearanceCheckboxes();
            }
            this.Invalidate();
        }

        private void conEditMarkers_Click(object sender, EventArgs e)
        {
            if (markerListForm == null || markerListForm.IsDisposed)
            {
                markerListForm = new MarkerListForm(CustomMarkers, Settings);
                markerListForm.TopMost = this.TopMost;
                markerListForm.Show(this);
            }
            else
            {
                if (!markerListForm.Visible)
                    markerListForm.Show(this);
                markerListForm.Activate();
            }
        }

        private void conClearCustomMarker_Click(object sender, EventArgs e)
        {
            CustomMarkers.Clear();
            this.Invalidate();
        }

        private void conTopmost_Click(object sender, EventArgs e) => TopMost = !TopMost;

        private void changeRulerMode(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem it in conRulerMode.DropDownItems)
                it.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
            ResizeMode = (FormResizeMode)Enum.Parse(typeof(FormResizeMode), (string)((ToolStripMenuItem)sender).Tag);
        }

        private void changeOpacity(bool increase)
        {
            int current = 0;
            foreach (ToolStripMenuItem item in conOpacity.DropDownItems)
            {
                if (item.Checked)
                {
                    item.Checked = false;
                    break;
                }
                current++;
            }
            // drop down items are in order from highest to lowest, therefore reverse
            int newIndex = increase ? current - 1 : current + 1;
            newIndex = Math.Max(0, Math.Min(newIndex, conOpacity.DropDownItems.Count - 1));
            changeOpacity(conOpacity.DropDownItems[newIndex], EventArgs.Empty);
        }

        private void changeOpacity(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem it in conOpacity.DropDownItems)
                it.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
            int opacity = int.Parse((String)((ToolStripMenuItem)sender).Tag);
            this.Opacity = (double)opacity / 100;
        }

        private void conFlipHorizontally_Click(object sender, EventArgs e)
        {
            Settings.RulerTransform ^= RulerTransform.FlippedX;
            this.Invalidate();
        }

        private void conFlipVertically_Click(object sender, EventArgs e)
        {
            Settings.RulerTransform ^= RulerTransform.FlippedY;
            this.Invalidate();
        }

        private void conSlimMode_Click(object sender, EventArgs e)
        {
            Settings.SlimMode = !Settings.SlimMode;
            this.SetRestrictSize(Settings.SlimMode ? RulerPainter.RULER_WIDTH_SLIM : RulerPainter.RULER_WIDTH_WIDE);
        }

        private void conLength_Click(object sender, EventArgs e)
        {
            SetSizeForm sizeForm = new SetSizeForm(this.Size, Settings);
            sizeForm.TopMost = this.TopMost;
            if (sizeForm.ShowDialog(this) == DialogResult.OK)
            {
                int w = (int)Math.Round(sizeForm.RulerWidth);
                int h = (int)Math.Round(sizeForm.RulerHeight);
                // if both width and height are set, switch into 2d mode
                if (w > RestrictSize && h > RestrictSize)
                    ResizeMode = FormResizeMode.TwoDimensional;
                this.Width = w;
                this.Height = h;
            }
        }

        private void setToolTip()
        {
            // Tool tip
            if (Settings.ShowToolTip)
            {
                rulerToolTip.SetToolTip(this,
                    String.Format(Resources.ToolTipText, Width, Height, $"{Left}, {Top}"));
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
                applySettings();
                this.Invalidate();
            }
        }

        private void conCalibrate_Click(object sender, EventArgs e)
        {
            CalibrationForm scalingForm = new CalibrationForm(Settings);
            if (scalingForm.ShowDialog(this) == DialogResult.OK)
            {
                Settings.MonitorDpi = scalingForm.MonitorDpi;
                Settings.MonitorScaling = scalingForm.MonitorScaling;
                Settings.InvokeChanged();
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

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }
    }
}
