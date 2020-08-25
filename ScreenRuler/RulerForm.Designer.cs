namespace ScreenRuler
{
    partial class RulerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulerForm));
            this.contxtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conMeasure = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.conTopmost = new System.Windows.Forms.ToolStripMenuItem();
            this.conMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.conRulerMode = new System.Windows.Forms.ToolStripMenuItem();
            this.conModeHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.conModeVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.conModeTwoDimensional = new System.Windows.Forms.ToolStripMenuItem();
            this.conOpacity = new System.Windows.Forms.ToolStripMenuItem();
            this.conHigh = new System.Windows.Forms.ToolStripMenuItem();
            this.conDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.conMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.conLow = new System.Windows.Forms.ToolStripMenuItem();
            this.conVeryLow = new System.Windows.Forms.ToolStripMenuItem();
            this.conSlimMode = new System.Windows.Forms.ToolStripMenuItem();
            this.comUnits = new System.Windows.Forms.ToolStripComboBox();
            this.conLength = new System.Windows.Forms.ToolStripMenuItem();
            this.conFollowMousePointer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.conMultiMarking = new System.Windows.Forms.ToolStripMenuItem();
            this.conClearCustomMarker = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conCalibrate = new System.Windows.Forms.ToolStripMenuItem();
            this.conHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.conAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.conExit = new System.Windows.Forms.ToolStripMenuItem();
            this.rulerToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contxtAppearance = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conMarkCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.conMarkThirds = new System.Windows.Forms.ToolStripMenuItem();
            this.conMarkGolden = new System.Windows.Forms.ToolStripMenuItem();
            this.conMarkMouse = new System.Windows.Forms.ToolStripMenuItem();
            this.conOffsetLength = new System.Windows.Forms.ToolStripMenuItem();
            this.appearanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conHideRulerScale = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.contxtMenu.SuspendLayout();
            this.contxtAppearance.SuspendLayout();
            this.SuspendLayout();
            // 
            // contxtMenu
            // 
            this.contxtMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contxtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conMeasure,
            this.toolStripSeparator4,
            this.conTopmost,
            this.conMinimize,
            this.conRulerMode,
            this.conOpacity,
            this.conSlimMode,
            this.comUnits,
            this.conLength,
            this.conFollowMousePointer,
            this.toolStripSeparator1,
            this.appearanceToolStripMenuItem,
            this.conMultiMarking,
            this.conClearCustomMarker,
            this.toolStripSeparator3,
            this.settingsToolStripMenuItem,
            this.conCalibrate,
            this.conHelp,
            this.conAbout,
            this.toolStripSeparator2,
            this.conExit});
            this.contxtMenu.Name = "contxtMenu";
            resources.ApplyResources(this.contxtMenu, "contxtMenu");
            this.contxtMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contxtMenu_Opening);
            // 
            // conMeasure
            // 
            this.conMeasure.Name = "conMeasure";
            resources.ApplyResources(this.conMeasure, "conMeasure");
            this.conMeasure.Click += new System.EventHandler(this.conMeasure_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // conTopmost
            // 
            this.conTopmost.Checked = true;
            this.conTopmost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.conTopmost.Name = "conTopmost";
            resources.ApplyResources(this.conTopmost, "conTopmost");
            this.conTopmost.Click += new System.EventHandler(this.conTopmost_Click);
            // 
            // conMinimize
            // 
            this.conMinimize.Name = "conMinimize";
            resources.ApplyResources(this.conMinimize, "conMinimize");
            this.conMinimize.Click += new System.EventHandler(this.conMinimize_Click);
            // 
            // conRulerMode
            // 
            this.conRulerMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conModeHorizontal,
            this.conModeVertical,
            this.conModeTwoDimensional});
            this.conRulerMode.Name = "conRulerMode";
            resources.ApplyResources(this.conRulerMode, "conRulerMode");
            this.conRulerMode.DropDownOpening += new System.EventHandler(this.conRulerMode_DropDownOpening);
            // 
            // conModeHorizontal
            // 
            this.conModeHorizontal.Name = "conModeHorizontal";
            resources.ApplyResources(this.conModeHorizontal, "conModeHorizontal");
            this.conModeHorizontal.Tag = "Horizontal";
            this.conModeHorizontal.Click += new System.EventHandler(this.changeRulerMode);
            // 
            // conModeVertical
            // 
            this.conModeVertical.Name = "conModeVertical";
            resources.ApplyResources(this.conModeVertical, "conModeVertical");
            this.conModeVertical.Tag = "Vertical";
            this.conModeVertical.Click += new System.EventHandler(this.changeRulerMode);
            // 
            // conModeTwoDimensional
            // 
            this.conModeTwoDimensional.Name = "conModeTwoDimensional";
            resources.ApplyResources(this.conModeTwoDimensional, "conModeTwoDimensional");
            this.conModeTwoDimensional.Tag = "TwoDimensional";
            this.conModeTwoDimensional.Click += new System.EventHandler(this.changeRulerMode);
            // 
            // conOpacity
            // 
            this.conOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conHigh,
            this.conDefault,
            this.conMedium,
            this.conLow,
            this.conVeryLow});
            this.conOpacity.Name = "conOpacity";
            resources.ApplyResources(this.conOpacity, "conOpacity");
            // 
            // conHigh
            // 
            this.conHigh.Name = "conHigh";
            resources.ApplyResources(this.conHigh, "conHigh");
            this.conHigh.Tag = "100";
            this.conHigh.Click += new System.EventHandler(this.changeOpacity);
            // 
            // conDefault
            // 
            this.conDefault.Name = "conDefault";
            resources.ApplyResources(this.conDefault, "conDefault");
            this.conDefault.Tag = "80";
            this.conDefault.Click += new System.EventHandler(this.changeOpacity);
            // 
            // conMedium
            // 
            this.conMedium.Name = "conMedium";
            resources.ApplyResources(this.conMedium, "conMedium");
            this.conMedium.Tag = "60";
            this.conMedium.Click += new System.EventHandler(this.changeOpacity);
            // 
            // conLow
            // 
            this.conLow.Name = "conLow";
            resources.ApplyResources(this.conLow, "conLow");
            this.conLow.Tag = "40";
            this.conLow.Click += new System.EventHandler(this.changeOpacity);
            // 
            // conVeryLow
            // 
            this.conVeryLow.Name = "conVeryLow";
            resources.ApplyResources(this.conVeryLow, "conVeryLow");
            this.conVeryLow.Tag = "20";
            this.conVeryLow.Click += new System.EventHandler(this.changeOpacity);
            // 
            // conSlimMode
            // 
            this.conSlimMode.Name = "conSlimMode";
            resources.ApplyResources(this.conSlimMode, "conSlimMode");
            this.conSlimMode.Click += new System.EventHandler(this.conSlimMode_Click);
            // 
            // comUnits
            // 
            this.comUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comUnits.Name = "comUnits";
            resources.ApplyResources(this.comUnits, "comUnits");
            this.comUnits.SelectedIndexChanged += new System.EventHandler(this.comUnits_SelectedIndexChanged);
            // 
            // conLength
            // 
            this.conLength.Name = "conLength";
            resources.ApplyResources(this.conLength, "conLength");
            this.conLength.Click += new System.EventHandler(this.conLength_Click);
            // 
            // conFollowMousePointer
            // 
            this.conFollowMousePointer.Name = "conFollowMousePointer";
            resources.ApplyResources(this.conFollowMousePointer, "conFollowMousePointer");
            this.conFollowMousePointer.Click += new System.EventHandler(this.conFollowMousePointer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // conMultiMarking
            // 
            this.conMultiMarking.Name = "conMultiMarking";
            resources.ApplyResources(this.conMultiMarking, "conMultiMarking");
            this.conMultiMarking.Click += new System.EventHandler(this.conMultiMarking_Click);
            // 
            // conClearCustomMarker
            // 
            this.conClearCustomMarker.Name = "conClearCustomMarker";
            resources.ApplyResources(this.conClearCustomMarker, "conClearCustomMarker");
            this.conClearCustomMarker.Click += new System.EventHandler(this.conClearCustomMarker_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // conCalibrate
            // 
            this.conCalibrate.Name = "conCalibrate";
            resources.ApplyResources(this.conCalibrate, "conCalibrate");
            this.conCalibrate.Click += new System.EventHandler(this.conCalibrate_Click);
            // 
            // conHelp
            // 
            this.conHelp.Name = "conHelp";
            resources.ApplyResources(this.conHelp, "conHelp");
            this.conHelp.Click += new System.EventHandler(this.conHelp_Click);
            // 
            // conAbout
            // 
            this.conAbout.Name = "conAbout";
            resources.ApplyResources(this.conAbout, "conAbout");
            this.conAbout.Click += new System.EventHandler(this.conAbout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // conExit
            // 
            this.conExit.Name = "conExit";
            resources.ApplyResources(this.conExit, "conExit");
            this.conExit.Click += new System.EventHandler(this.conExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contxtMenu;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contxtAppearance
            // 
            this.contxtAppearance.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conMarkCenter,
            this.conMarkThirds,
            this.conMarkGolden,
            this.conMarkMouse,
            this.conOffsetLength,
            this.toolStripSeparator5,
            this.conHideRulerScale});
            this.contxtAppearance.Name = "contxtAppearance";
            resources.ApplyResources(this.contxtAppearance, "contxtAppearance");
            // 
            // conMarkCenter
            // 
            this.conMarkCenter.Name = "conMarkCenter";
            resources.ApplyResources(this.conMarkCenter, "conMarkCenter");
            this.conMarkCenter.Click += new System.EventHandler(this.conMarkCenter_Click);
            // 
            // conMarkThirds
            // 
            this.conMarkThirds.Name = "conMarkThirds";
            resources.ApplyResources(this.conMarkThirds, "conMarkThirds");
            this.conMarkThirds.Click += new System.EventHandler(this.conMarkThirds_Click);
            // 
            // conMarkGolden
            // 
            this.conMarkGolden.Name = "conMarkGolden";
            resources.ApplyResources(this.conMarkGolden, "conMarkGolden");
            this.conMarkGolden.Click += new System.EventHandler(this.conMarkGolden_Click);
            // 
            // conMarkMouse
            // 
            this.conMarkMouse.Checked = true;
            this.conMarkMouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.conMarkMouse.Name = "conMarkMouse";
            resources.ApplyResources(this.conMarkMouse, "conMarkMouse");
            this.conMarkMouse.Click += new System.EventHandler(this.conMarkMouse_Click);
            // 
            // conOffsetLength
            // 
            this.conOffsetLength.Name = "conOffsetLength";
            resources.ApplyResources(this.conOffsetLength, "conOffsetLength");
            this.conOffsetLength.Click += new System.EventHandler(this.conOffsetLength_Click);
            // 
            // appearanceToolStripMenuItem
            // 
            this.appearanceToolStripMenuItem.DropDown = this.contxtAppearance;
            this.appearanceToolStripMenuItem.Name = "appearanceToolStripMenuItem";
            resources.ApplyResources(this.appearanceToolStripMenuItem, "appearanceToolStripMenuItem");
            // 
            // conHideRulerScale
            // 
            this.conHideRulerScale.Name = "conHideRulerScale";
            resources.ApplyResources(this.conHideRulerScale, "conHideRulerScale");
            this.conHideRulerScale.Click += new System.EventHandler(this.conHideRulerScale_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // RulerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ContextMenuStrip = this.contxtMenu;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "RulerForm";
            this.Opacity = 0.8D;
            this.TransparencyKey = System.Drawing.Color.Thistle;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RulerForm_FormClosing);
            this.Load += new System.EventHandler(this.RulerForm_Load);
            this.SizeChanged += new System.EventHandler(this.RulerForm_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RulerForm_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RulerForm_MouseDoubleClick);
            this.Move += new System.EventHandler(this.RulerForm_Move);
            this.contxtMenu.ResumeLayout(false);
            this.contxtAppearance.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contxtMenu;
        private System.Windows.Forms.ToolStripMenuItem conExit;
        private System.Windows.Forms.ToolStripMenuItem conTopmost;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem conAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem conOpacity;
        private System.Windows.Forms.ToolStripMenuItem conLength;
        private System.Windows.Forms.ToolStripMenuItem conHigh;
        private System.Windows.Forms.ToolStripMenuItem conDefault;
        private System.Windows.Forms.ToolStripMenuItem conLow;
        private System.Windows.Forms.ToolStripMenuItem conVeryLow;
        private System.Windows.Forms.ToolStripMenuItem conClearCustomMarker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem conHelp;
        private System.Windows.Forms.ToolStripMenuItem conMultiMarking;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox comUnits;
        private System.Windows.Forms.ToolStripMenuItem conMinimize;
        private System.Windows.Forms.ToolStripMenuItem conMeasure;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolTip rulerToolTip;
        private System.Windows.Forms.ToolStripMenuItem conCalibrate;
        private System.Windows.Forms.ToolStripMenuItem conRulerMode;
        private System.Windows.Forms.ToolStripMenuItem conModeHorizontal;
        private System.Windows.Forms.ToolStripMenuItem conModeVertical;
        private System.Windows.Forms.ToolStripMenuItem conModeTwoDimensional;
        private System.Windows.Forms.ToolStripMenuItem conSlimMode;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem conFollowMousePointer;
        private System.Windows.Forms.ToolStripMenuItem conMedium;
        private System.Windows.Forms.ToolStripMenuItem appearanceToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contxtAppearance;
        private System.Windows.Forms.ToolStripMenuItem conMarkCenter;
        private System.Windows.Forms.ToolStripMenuItem conMarkThirds;
        private System.Windows.Forms.ToolStripMenuItem conMarkGolden;
        private System.Windows.Forms.ToolStripMenuItem conMarkMouse;
        private System.Windows.Forms.ToolStripMenuItem conOffsetLength;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem conHideRulerScale;
    }
}

