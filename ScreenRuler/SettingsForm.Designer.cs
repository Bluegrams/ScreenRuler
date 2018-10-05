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
            this.label2 = new System.Windows.Forms.Label();
            this.txtDPI = new System.Windows.Forms.TextBox();
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
            this.groupBox1.SuspendLayout();
            this.grpColors.SuspendLayout();
            this.panCustomColors.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDPI);
            this.groupBox1.Controls.Add(this.comUnits);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtDPI
            // 
            resources.ApplyResources(this.txtDPI, "txtDPI");
            this.txtDPI.Name = "txtDPI";
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
            // SettingsForm
            // 
            this.AcceptButton = this.butSubmit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.Controls.Add(this.butSubmit);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.grpColors);
            this.Controls.Add(this.groupBox1);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDPI;
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
    }
}