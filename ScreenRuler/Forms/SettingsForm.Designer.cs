namespace ScreenRuler
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butConfigure = new System.Windows.Forms.Button();
            this.lblScaling = new System.Windows.Forms.Label();
            this.comUnits = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpColors = new System.Windows.Forms.GroupBox();
            this.panCustomColors = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.butColorTicks = new System.Windows.Forms.Button();
            this.butColorMouseMarker = new System.Windows.Forms.Button();
            this.butColorBackground = new System.Windows.Forms.Button();
            this.butColorDivideMarkers = new System.Windows.Forms.Button();
            this.butColorCustomMarkers = new System.Windows.Forms.Button();
            this.radCustom = new System.Windows.Forms.RadioButton();
            this.radDark = new System.Windows.Forms.RadioButton();
            this.radLight = new System.Windows.Forms.RadioButton();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSubmit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkLimitOneMarker = new System.Windows.Forms.CheckBox();
            this.chkMarkerSymbol = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numMarkerThickness = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkSnapToScreenEdges = new System.Windows.Forms.CheckBox();
            this.chkFollowMousePointerCenter = new System.Windows.Forms.CheckBox();
            this.chkNotifyIcon = new System.Windows.Forms.CheckBox();
            this.chkToolTip = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numSmallStep = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numLargeStep = new System.Windows.Forms.NumericUpDown();
            this.numMediumStep = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.butShortcuts = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grpColors.SuspendLayout();
            this.panCustomColors.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMarkerThickness)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmallStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLargeStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMediumStep)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butConfigure);
            this.groupBox1.Controls.Add(this.lblScaling);
            this.groupBox1.Controls.Add(this.comUnits);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // butConfigure
            // 
            resources.ApplyResources(this.butConfigure, "butConfigure");
            this.butConfigure.Name = "butConfigure";
            this.butConfigure.UseVisualStyleBackColor = true;
            this.butConfigure.Click += new System.EventHandler(this.butConfigure_Click);
            // 
            // lblScaling
            // 
            resources.ApplyResources(this.lblScaling, "lblScaling");
            this.lblScaling.Name = "lblScaling";
            // 
            // comUnits
            // 
            this.comUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comUnits.FormattingEnabled = true;
            resources.ApplyResources(this.comUnits, "comUnits");
            this.comUnits.Name = "comUnits";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // grpColors
            // 
            this.grpColors.Controls.Add(this.panCustomColors);
            this.grpColors.Controls.Add(this.radCustom);
            this.grpColors.Controls.Add(this.radDark);
            this.grpColors.Controls.Add(this.radLight);
            resources.ApplyResources(this.grpColors, "grpColors");
            this.grpColors.Name = "grpColors";
            this.grpColors.TabStop = false;
            // 
            // panCustomColors
            // 
            resources.ApplyResources(this.panCustomColors, "panCustomColors");
            this.panCustomColors.Controls.Add(this.label3, 1, 0);
            this.panCustomColors.Controls.Add(this.label4, 3, 0);
            this.panCustomColors.Controls.Add(this.label5, 1, 2);
            this.panCustomColors.Controls.Add(this.label6, 3, 1);
            this.panCustomColors.Controls.Add(this.label7, 1, 1);
            this.panCustomColors.Controls.Add(this.butColorTicks, 2, 0);
            this.panCustomColors.Controls.Add(this.butColorMouseMarker, 2, 1);
            this.panCustomColors.Controls.Add(this.butColorBackground, 0, 0);
            this.panCustomColors.Controls.Add(this.butColorDivideMarkers, 0, 1);
            this.panCustomColors.Controls.Add(this.butColorCustomMarkers, 0, 2);
            this.panCustomColors.Name = "panCustomColors";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // butColorTicks
            // 
            resources.ApplyResources(this.butColorTicks, "butColorTicks");
            this.butColorTicks.Name = "butColorTicks";
            this.butColorTicks.Tag = "TickColor";
            this.butColorTicks.UseVisualStyleBackColor = false;
            this.butColorTicks.Click += new System.EventHandler(this.butColorChooser_Click);
            // 
            // butColorMouseMarker
            // 
            resources.ApplyResources(this.butColorMouseMarker, "butColorMouseMarker");
            this.butColorMouseMarker.Name = "butColorMouseMarker";
            this.butColorMouseMarker.Tag = "MouseLineColor";
            this.butColorMouseMarker.UseVisualStyleBackColor = true;
            this.butColorMouseMarker.Click += new System.EventHandler(this.butColorChooser_Click);
            // 
            // butColorBackground
            // 
            resources.ApplyResources(this.butColorBackground, "butColorBackground");
            this.butColorBackground.Name = "butColorBackground";
            this.butColorBackground.Tag = "Background";
            this.butColorBackground.UseVisualStyleBackColor = true;
            this.butColorBackground.Click += new System.EventHandler(this.butColorChooser_Click);
            // 
            // butColorDivideMarkers
            // 
            resources.ApplyResources(this.butColorDivideMarkers, "butColorDivideMarkers");
            this.butColorDivideMarkers.Name = "butColorDivideMarkers";
            this.butColorDivideMarkers.Tag = "CenterLineColor";
            this.butColorDivideMarkers.UseVisualStyleBackColor = true;
            this.butColorDivideMarkers.Click += new System.EventHandler(this.butColorChooser_Click);
            // 
            // butColorCustomMarkers
            // 
            resources.ApplyResources(this.butColorCustomMarkers, "butColorCustomMarkers");
            this.butColorCustomMarkers.Name = "butColorCustomMarkers";
            this.butColorCustomMarkers.Tag = "CustomLinesColor";
            this.butColorCustomMarkers.UseVisualStyleBackColor = true;
            this.butColorCustomMarkers.Click += new System.EventHandler(this.butColorChooser_Click);
            // 
            // radCustom
            // 
            resources.ApplyResources(this.radCustom, "radCustom");
            this.radCustom.Name = "radCustom";
            this.radCustom.TabStop = true;
            this.radCustom.Tag = "Custom";
            this.radCustom.UseVisualStyleBackColor = true;
            this.radCustom.CheckedChanged += new System.EventHandler(this.radTheme_CheckedChanged);
            // 
            // radDark
            // 
            resources.ApplyResources(this.radDark, "radDark");
            this.radDark.Name = "radDark";
            this.radDark.TabStop = true;
            this.radDark.Tag = "Dark";
            this.radDark.UseVisualStyleBackColor = true;
            this.radDark.CheckedChanged += new System.EventHandler(this.radTheme_CheckedChanged);
            // 
            // radLight
            // 
            resources.ApplyResources(this.radLight, "radLight");
            this.radLight.Name = "radLight";
            this.radLight.TabStop = true;
            this.radLight.Tag = "Light";
            this.radLight.UseVisualStyleBackColor = true;
            this.radLight.CheckedChanged += new System.EventHandler(this.radTheme_CheckedChanged);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.butCancel, "butCancel");
            this.butCancel.Name = "butCancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butSubmit
            // 
            this.butSubmit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.butSubmit, "butSubmit");
            this.butSubmit.Name = "butSubmit";
            this.butSubmit.UseVisualStyleBackColor = true;
            this.butSubmit.Click += new System.EventHandler(this.butSubmit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.grpColors);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox4);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkLimitOneMarker);
            this.groupBox4.Controls.Add(this.chkMarkerSymbol);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.numMarkerThickness);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // chkLimitOneMarker
            // 
            resources.ApplyResources(this.chkLimitOneMarker, "chkLimitOneMarker");
            this.chkLimitOneMarker.Name = "chkLimitOneMarker";
            this.chkLimitOneMarker.UseVisualStyleBackColor = true;
            // 
            // chkMarkerSymbol
            // 
            resources.ApplyResources(this.chkMarkerSymbol, "chkMarkerSymbol");
            this.chkMarkerSymbol.Name = "chkMarkerSymbol";
            this.chkMarkerSymbol.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // numMarkerThickness
            // 
            resources.ApplyResources(this.numMarkerThickness, "numMarkerThickness");
            this.numMarkerThickness.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMarkerThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMarkerThickness.Name = "numMarkerThickness";
            this.numMarkerThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkSnapToScreenEdges);
            this.groupBox3.Controls.Add(this.chkFollowMousePointerCenter);
            this.groupBox3.Controls.Add(this.chkNotifyIcon);
            this.groupBox3.Controls.Add(this.chkToolTip);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // chkSnapToScreenEdges
            // 
            resources.ApplyResources(this.chkSnapToScreenEdges, "chkSnapToScreenEdges");
            this.chkSnapToScreenEdges.Name = "chkSnapToScreenEdges";
            this.chkSnapToScreenEdges.UseVisualStyleBackColor = true;
            // 
            // chkFollowMousePointerCenter
            // 
            resources.ApplyResources(this.chkFollowMousePointerCenter, "chkFollowMousePointerCenter");
            this.chkFollowMousePointerCenter.Name = "chkFollowMousePointerCenter";
            this.chkFollowMousePointerCenter.UseVisualStyleBackColor = true;
            // 
            // chkNotifyIcon
            // 
            resources.ApplyResources(this.chkNotifyIcon, "chkNotifyIcon");
            this.chkNotifyIcon.Name = "chkNotifyIcon";
            this.chkNotifyIcon.UseVisualStyleBackColor = true;
            // 
            // chkToolTip
            // 
            resources.ApplyResources(this.chkToolTip, "chkToolTip");
            this.chkToolTip.Name = "chkToolTip";
            this.chkToolTip.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numSmallStep);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numLargeStep);
            this.groupBox2.Controls.Add(this.numMediumStep);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // numSmallStep
            // 
            resources.ApplyResources(this.numSmallStep, "numSmallStep");
            this.numSmallStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSmallStep.Name = "numSmallStep";
            this.numSmallStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // numLargeStep
            // 
            resources.ApplyResources(this.numLargeStep, "numLargeStep");
            this.numLargeStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLargeStep.Name = "numLargeStep";
            this.numLargeStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMediumStep
            // 
            resources.ApplyResources(this.numMediumStep, "numMediumStep");
            this.numMediumStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMediumStep.Name = "numMediumStep";
            this.numMediumStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.butShortcuts);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // butShortcuts
            // 
            resources.ApplyResources(this.butShortcuts, "butShortcuts");
            this.butShortcuts.Name = "butShortcuts";
            this.butShortcuts.UseVisualStyleBackColor = true;
            this.butShortcuts.Click += new System.EventHandler(this.butShortcuts_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.butSubmit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.butSubmit);
            this.Controls.Add(this.butCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpColors.ResumeLayout(false);
            this.grpColors.PerformLayout();
            this.panCustomColors.ResumeLayout(false);
            this.panCustomColors.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMarkerThickness)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSmallStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLargeStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMediumStep)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblScaling;
        private System.Windows.Forms.ComboBox comUnits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpColors;
        private System.Windows.Forms.RadioButton radCustom;
        private System.Windows.Forms.RadioButton radDark;
        private System.Windows.Forms.RadioButton radLight;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSubmit;
        private System.Windows.Forms.TableLayoutPanel panCustomColors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button butColorTicks;
        private System.Windows.Forms.Button butColorMouseMarker;
        private System.Windows.Forms.Button butColorBackground;
        private System.Windows.Forms.Button butColorDivideMarkers;
        private System.Windows.Forms.Button butColorCustomMarkers;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numLargeStep;
        private System.Windows.Forms.NumericUpDown numMediumStep;
        private System.Windows.Forms.CheckBox chkToolTip;
        private System.Windows.Forms.Button butConfigure;
        private System.Windows.Forms.CheckBox chkNotifyIcon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSmallStep;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkLimitOneMarker;
        private System.Windows.Forms.CheckBox chkMarkerSymbol;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numMarkerThickness;
        private System.Windows.Forms.CheckBox chkFollowMousePointerCenter;
        private System.Windows.Forms.CheckBox chkSnapToScreenEdges;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button butShortcuts;
    }
}