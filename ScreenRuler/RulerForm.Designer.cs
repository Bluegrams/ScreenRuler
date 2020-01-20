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
            this.conVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.conOpacity = new System.Windows.Forms.ToolStripMenuItem();
            this.conHigh = new System.Windows.Forms.ToolStripMenuItem();
            this.conDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.conLow = new System.Windows.Forms.ToolStripMenuItem();
            this.conVeryLow = new System.Windows.Forms.ToolStripMenuItem();
            this.comUnits = new System.Windows.Forms.ToolStripComboBox();
            this.conLength = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.conMarkCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.conMarkThirds = new System.Windows.Forms.ToolStripMenuItem();
            this.conMarkGolden = new System.Windows.Forms.ToolStripMenuItem();
            this.conMarkMouse = new System.Windows.Forms.ToolStripMenuItem();
            this.conOffsetLength = new System.Windows.Forms.ToolStripMenuItem();
            this.conMultiMarking = new System.Windows.Forms.ToolStripMenuItem();
            this.conClearCustomMarker = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.conAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.conExit = new System.Windows.Forms.ToolStripMenuItem();
            this.rulerToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contxtMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // contxtMenu
            // 
            resources.ApplyResources(this.contxtMenu, "contxtMenu");
            this.contxtMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contxtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conMeasure,
            this.toolStripSeparator4,
            this.conTopmost,
            this.conMinimize,
            this.conVertical,
            this.conOpacity,
            this.comUnits,
            this.conLength,
            this.toolStripSeparator1,
            this.conMarkCenter,
            this.conMarkThirds,
            this.conMarkGolden,
            this.conMarkMouse,
            this.conOffsetLength,
            this.conMultiMarking,
            this.conClearCustomMarker,
            this.toolStripSeparator3,
            this.settingsToolStripMenuItem,
            this.conHelp,
            this.conAbout,
            this.toolStripSeparator2,
            this.conExit});
            this.contxtMenu.Name = "contxtMenu";
            this.rulerToolTip.SetToolTip(this.contxtMenu, resources.GetString("contxtMenu.ToolTip"));
            this.contxtMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contxtMenu_Opening);
            // 
            // conMeasure
            // 
            resources.ApplyResources(this.conMeasure, "conMeasure");
            this.conMeasure.Name = "conMeasure";
            this.conMeasure.Click += new System.EventHandler(this.conMeasure_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // conTopmost
            // 
            resources.ApplyResources(this.conTopmost, "conTopmost");
            this.conTopmost.Checked = true;
            this.conTopmost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.conTopmost.Name = "conTopmost";
            this.conTopmost.Click += new System.EventHandler(this.conTopmost_Click);
            // 
            // conMinimize
            // 
            resources.ApplyResources(this.conMinimize, "conMinimize");
            this.conMinimize.Name = "conMinimize";
            this.conMinimize.Click += new System.EventHandler(this.conMinimize_Click);
            // 
            // conVertical
            // 
            resources.ApplyResources(this.conVertical, "conVertical");
            this.conVertical.Name = "conVertical";
            this.conVertical.Click += new System.EventHandler(this.conVertical_Click);
            // 
            // conOpacity
            // 
            resources.ApplyResources(this.conOpacity, "conOpacity");
            this.conOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conHigh,
            this.conDefault,
            this.conLow,
            this.conVeryLow});
            this.conOpacity.Name = "conOpacity";
            // 
            // conHigh
            // 
            resources.ApplyResources(this.conHigh, "conHigh");
            this.conHigh.Name = "conHigh";
            this.conHigh.Tag = "100";
            this.conHigh.Click += new System.EventHandler(this.changeOpacity);
            // 
            // conDefault
            // 
            resources.ApplyResources(this.conDefault, "conDefault");
            this.conDefault.Name = "conDefault";
            this.conDefault.Tag = "80";
            this.conDefault.Click += new System.EventHandler(this.changeOpacity);
            // 
            // conLow
            // 
            resources.ApplyResources(this.conLow, "conLow");
            this.conLow.Name = "conLow";
            this.conLow.Tag = "60";
            this.conLow.Click += new System.EventHandler(this.changeOpacity);
            // 
            // conVeryLow
            // 
            resources.ApplyResources(this.conVeryLow, "conVeryLow");
            this.conVeryLow.Name = "conVeryLow";
            this.conVeryLow.Tag = "40";
            this.conVeryLow.Click += new System.EventHandler(this.changeOpacity);
            // 
            // comUnits
            // 
            resources.ApplyResources(this.comUnits, "comUnits");
            this.comUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comUnits.Name = "comUnits";
            this.comUnits.SelectedIndexChanged += new System.EventHandler(this.comUnits_SelectedIndexChanged);
            // 
            // conLength
            // 
            resources.ApplyResources(this.conLength, "conLength");
            this.conLength.Name = "conLength";
            this.conLength.Click += new System.EventHandler(this.conLength_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // conMarkCenter
            // 
            resources.ApplyResources(this.conMarkCenter, "conMarkCenter");
            this.conMarkCenter.Name = "conMarkCenter";
            this.conMarkCenter.Click += new System.EventHandler(this.conMarkCenter_Click);
            // 
            // conMarkThirds
            // 
            resources.ApplyResources(this.conMarkThirds, "conMarkThirds");
            this.conMarkThirds.Name = "conMarkThirds";
            this.conMarkThirds.Click += new System.EventHandler(this.conMarkThirds_Click);
            // 
            // conMarkGolden
            // 
            resources.ApplyResources(this.conMarkGolden, "conMarkGolden");
            this.conMarkGolden.Name = "conMarkGolden";
            this.conMarkGolden.Click += new System.EventHandler(this.conMarkGolden_Click);
            // 
            // conMarkMouse
            // 
            resources.ApplyResources(this.conMarkMouse, "conMarkMouse");
            this.conMarkMouse.Checked = true;
            this.conMarkMouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.conMarkMouse.Name = "conMarkMouse";
            this.conMarkMouse.Click += new System.EventHandler(this.conMarkMouse_Click);
            // 
            // conOffsetLength
            // 
            resources.ApplyResources(this.conOffsetLength, "conOffsetLength");
            this.conOffsetLength.Name = "conOffsetLength";
            this.conOffsetLength.Click += new System.EventHandler(this.conOffsetLength_Click);
            // 
            // conMultiMarking
            // 
            resources.ApplyResources(this.conMultiMarking, "conMultiMarking");
            this.conMultiMarking.Name = "conMultiMarking";
            this.conMultiMarking.Click += new System.EventHandler(this.conMultiMarking_Click);
            // 
            // conClearCustomMarker
            // 
            resources.ApplyResources(this.conClearCustomMarker, "conClearCustomMarker");
            this.conClearCustomMarker.Name = "conClearCustomMarker";
            this.conClearCustomMarker.Click += new System.EventHandler(this.conClearCustomMarker_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // conHelp
            // 
            resources.ApplyResources(this.conHelp, "conHelp");
            this.conHelp.Name = "conHelp";
            this.conHelp.Click += new System.EventHandler(this.conHelp_Click);
            // 
            // conAbout
            // 
            resources.ApplyResources(this.conAbout, "conAbout");
            this.conAbout.Name = "conAbout";
            this.conAbout.Click += new System.EventHandler(this.conAbout_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // conExit
            // 
            resources.ApplyResources(this.conExit, "conExit");
            this.conExit.Name = "conExit";
            this.conExit.Click += new System.EventHandler(this.conExit_Click);
            // 
            // RulerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.contxtMenu;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "RulerForm";
            this.Opacity = 0.8D;
            this.rulerToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.RulerForm_Load);
            this.SizeChanged += new System.EventHandler(this.RulerForm_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RulerForm_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RulerForm_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RulerForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RulerForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RulerForm_MouseUp);
            this.Move += new System.EventHandler(this.RulerForm_Move);
            this.contxtMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contxtMenu;
        private System.Windows.Forms.ToolStripMenuItem conExit;
        private System.Windows.Forms.ToolStripMenuItem conTopmost;
        private System.Windows.Forms.ToolStripMenuItem conVertical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem conAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem conOpacity;
        private System.Windows.Forms.ToolStripMenuItem conLength;
        private System.Windows.Forms.ToolStripMenuItem conHigh;
        private System.Windows.Forms.ToolStripMenuItem conDefault;
        private System.Windows.Forms.ToolStripMenuItem conLow;
        private System.Windows.Forms.ToolStripMenuItem conVeryLow;
        private System.Windows.Forms.ToolStripMenuItem conMarkCenter;
        private System.Windows.Forms.ToolStripMenuItem conMarkMouse;
        private System.Windows.Forms.ToolStripMenuItem conClearCustomMarker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem conHelp;
        private System.Windows.Forms.ToolStripMenuItem conMultiMarking;
        private System.Windows.Forms.ToolStripMenuItem conMarkThirds;
        private System.Windows.Forms.ToolStripMenuItem conMarkGolden;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox comUnits;
        private System.Windows.Forms.ToolStripMenuItem conMinimize;
        private System.Windows.Forms.ToolStripMenuItem conOffsetLength;
        private System.Windows.Forms.ToolStripMenuItem conMeasure;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolTip rulerToolTip;
    }
}

