namespace ScreenRuler
{
    partial class CalibrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationForm));
            this.numDpiH = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkHelp = new System.Windows.Forms.LinkLabel();
            this.butSubmit = new System.Windows.Forms.Button();
            this.numDpiV = new System.Windows.Forms.NumericUpDown();
            this.comDpiScalingMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageDPI = new System.Windows.Forms.TabPage();
            this.panDpiH = new System.Windows.Forms.Panel();
            this.panDpiV = new System.Windows.Forms.Panel();
            this.chkBidirectional = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageSize = new System.Windows.Forms.TabPage();
            this.panUnitV = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.numUnitV = new System.Windows.Forms.NumericUpDown();
            this.panUnitH = new System.Windows.Forms.Panel();
            this.numUnitH = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.comUnits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.comMonitors = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panMonitor = new System.Windows.Forms.Panel();
            this.butCurrentMonitor = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numDpiH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDpiV)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabPageDPI.SuspendLayout();
            this.panDpiH.SuspendLayout();
            this.panDpiV.SuspendLayout();
            this.tabPageSize.SuspendLayout();
            this.panUnitV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitV)).BeginInit();
            this.panUnitH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitH)).BeginInit();
            this.panMonitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // numDpiH
            // 
            this.numDpiH.DecimalPlaces = 2;
            resources.ApplyResources(this.numDpiH, "numDpiH");
            this.numDpiH.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDpiH.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDpiH.Name = "numDpiH";
            this.numDpiH.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDpiH.ValueChanged += new System.EventHandler(this.numDpiH_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lnkHelp
            // 
            resources.ApplyResources(this.lnkHelp, "lnkHelp");
            this.lnkHelp.Name = "lnkHelp";
            this.lnkHelp.TabStop = true;
            this.lnkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHelp_LinkClicked);
            // 
            // butSubmit
            // 
            resources.ApplyResources(this.butSubmit, "butSubmit");
            this.butSubmit.Name = "butSubmit";
            this.butSubmit.UseVisualStyleBackColor = true;
            this.butSubmit.Click += new System.EventHandler(this.butSubmit_Click);
            // 
            // numDpiV
            // 
            this.numDpiV.DecimalPlaces = 2;
            resources.ApplyResources(this.numDpiV, "numDpiV");
            this.numDpiV.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDpiV.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDpiV.Name = "numDpiV";
            this.numDpiV.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDpiV.ValueChanged += new System.EventHandler(this.numDpiV_ValueChanged);
            // 
            // comDpiScalingMode
            // 
            this.comDpiScalingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comDpiScalingMode.FormattingEnabled = true;
            resources.ApplyResources(this.comDpiScalingMode, "comDpiScalingMode");
            this.comDpiScalingMode.Name = "comDpiScalingMode";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageDPI);
            this.tabMain.Controls.Add(this.tabPageSize);
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            // 
            // tabPageDPI
            // 
            this.tabPageDPI.Controls.Add(this.panDpiH);
            this.tabPageDPI.Controls.Add(this.panDpiV);
            this.tabPageDPI.Controls.Add(this.label1);
            resources.ApplyResources(this.tabPageDPI, "tabPageDPI");
            this.tabPageDPI.Name = "tabPageDPI";
            this.tabPageDPI.UseVisualStyleBackColor = true;
            // 
            // panDpiH
            // 
            this.panDpiH.Controls.Add(this.label2);
            this.panDpiH.Controls.Add(this.numDpiH);
            resources.ApplyResources(this.panDpiH, "panDpiH");
            this.panDpiH.Name = "panDpiH";
            // 
            // panDpiV
            // 
            this.panDpiV.Controls.Add(this.chkBidirectional);
            this.panDpiV.Controls.Add(this.numDpiV);
            resources.ApplyResources(this.panDpiV, "panDpiV");
            this.panDpiV.Name = "panDpiV";
            // 
            // chkBidirectional
            // 
            resources.ApplyResources(this.chkBidirectional, "chkBidirectional");
            this.chkBidirectional.Name = "chkBidirectional";
            this.chkBidirectional.UseVisualStyleBackColor = true;
            this.chkBidirectional.CheckedChanged += new System.EventHandler(this.chkBidirectional_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabPageSize
            // 
            this.tabPageSize.Controls.Add(this.panUnitV);
            this.tabPageSize.Controls.Add(this.panUnitH);
            this.tabPageSize.Controls.Add(this.comUnits);
            this.tabPageSize.Controls.Add(this.label6);
            this.tabPageSize.Controls.Add(this.label5);
            resources.ApplyResources(this.tabPageSize, "tabPageSize");
            this.tabPageSize.Name = "tabPageSize";
            this.tabPageSize.UseVisualStyleBackColor = true;
            // 
            // panUnitV
            // 
            this.panUnitV.Controls.Add(this.label8);
            this.panUnitV.Controls.Add(this.numUnitV);
            resources.ApplyResources(this.panUnitV, "panUnitV");
            this.panUnitV.Name = "panUnitV";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // numUnitV
            // 
            this.numUnitV.DecimalPlaces = 2;
            resources.ApplyResources(this.numUnitV, "numUnitV");
            this.numUnitV.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUnitV.Name = "numUnitV";
            this.numUnitV.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUnitV.ValueChanged += new System.EventHandler(this.numUnitV_ValueChanged);
            // 
            // panUnitH
            // 
            this.panUnitH.Controls.Add(this.numUnitH);
            this.panUnitH.Controls.Add(this.label7);
            resources.ApplyResources(this.panUnitH, "panUnitH");
            this.panUnitH.Name = "panUnitH";
            // 
            // numUnitH
            // 
            this.numUnitH.DecimalPlaces = 2;
            resources.ApplyResources(this.numUnitH, "numUnitH");
            this.numUnitH.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUnitH.Name = "numUnitH";
            this.numUnitH.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numUnitH.ValueChanged += new System.EventHandler(this.numUnitH_ValueChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // comUnits
            // 
            this.comUnits.DisplayMember = "Text";
            this.comUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comUnits.FormattingEnabled = true;
            resources.ApplyResources(this.comUnits, "comUnits");
            this.comUnits.Name = "comUnits";
            this.comUnits.ValueMember = "Value";
            this.comUnits.SelectedIndexChanged += new System.EventHandler(this.comUnits_SelectedIndexChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.butCancel, "butCancel");
            this.butCancel.Name = "butCancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // comMonitors
            // 
            this.comMonitors.DisplayMember = "Text";
            this.comMonitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMonitors.FormattingEnabled = true;
            resources.ApplyResources(this.comMonitors, "comMonitors");
            this.comMonitors.Name = "comMonitors";
            this.comMonitors.ValueMember = "Value";
            this.comMonitors.SelectedIndexChanged += new System.EventHandler(this.comMonitors_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // panMonitor
            // 
            this.panMonitor.Controls.Add(this.butCurrentMonitor);
            this.panMonitor.Controls.Add(this.comMonitors);
            this.panMonitor.Controls.Add(this.label4);
            resources.ApplyResources(this.panMonitor, "panMonitor");
            this.panMonitor.Name = "panMonitor";
            // 
            // butCurrentMonitor
            // 
            resources.ApplyResources(this.butCurrentMonitor, "butCurrentMonitor");
            this.butCurrentMonitor.Name = "butCurrentMonitor";
            this.toolTip1.SetToolTip(this.butCurrentMonitor, resources.GetString("butCurrentMonitor.ToolTip"));
            this.butCurrentMonitor.UseVisualStyleBackColor = true;
            this.butCurrentMonitor.Click += new System.EventHandler(this.butCurrentMonitor_Click);
            // 
            // CalibrationForm
            // 
            this.AcceptButton = this.butSubmit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.Controls.Add(this.panMonitor);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.lnkHelp);
            this.Controls.Add(this.comDpiScalingMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalibrationForm";
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CalibrationForm_FormClosed);
            this.Load += new System.EventHandler(this.CalibrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDpiH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDpiV)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabPageDPI.ResumeLayout(false);
            this.tabPageDPI.PerformLayout();
            this.panDpiH.ResumeLayout(false);
            this.panDpiH.PerformLayout();
            this.panDpiV.ResumeLayout(false);
            this.panDpiV.PerformLayout();
            this.tabPageSize.ResumeLayout(false);
            this.tabPageSize.PerformLayout();
            this.panUnitV.ResumeLayout(false);
            this.panUnitV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitV)).EndInit();
            this.panUnitH.ResumeLayout(false);
            this.panUnitH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitH)).EndInit();
            this.panMonitor.ResumeLayout(false);
            this.panMonitor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numDpiH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butSubmit;
        private System.Windows.Forms.LinkLabel lnkHelp;
        private System.Windows.Forms.ComboBox comDpiScalingMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numDpiV;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageDPI;
        private System.Windows.Forms.TabPage tabPageSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comUnits;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numUnitV;
        private System.Windows.Forms.NumericUpDown numUnitH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Panel panDpiV;
        private System.Windows.Forms.Panel panDpiH;
        private System.Windows.Forms.Panel panUnitV;
        private System.Windows.Forms.Panel panUnitH;
        private System.Windows.Forms.CheckBox chkBidirectional;
        private System.Windows.Forms.ComboBox comMonitors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panMonitor;
        private System.Windows.Forms.Button butCurrentMonitor;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}