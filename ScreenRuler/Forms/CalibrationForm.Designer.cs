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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationForm));
            this.panPreview = new System.Windows.Forms.Panel();
            this.numScaling = new System.Windows.Forms.NumericUpDown();
            this.numDPI = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comUnits = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkHelp = new System.Windows.Forms.LinkLabel();
            this.butSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numScaling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDPI)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panPreview
            // 
            resources.ApplyResources(this.panPreview, "panPreview");
            this.panPreview.Name = "panPreview";
            this.panPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.panPreview_Paint);
            // 
            // numScaling
            // 
            this.numScaling.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            resources.ApplyResources(this.numScaling, "numScaling");
            this.numScaling.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numScaling.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numScaling.Name = "numScaling";
            this.numScaling.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numScaling.ValueChanged += new System.EventHandler(this.numScaling_ValueChanged);
            // 
            // numDPI
            // 
            this.numDPI.DecimalPlaces = 2;
            resources.ApplyResources(this.numDPI, "numDPI");
            this.numDPI.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDPI.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDPI.Name = "numDPI";
            this.numDPI.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDPI.ValueChanged += new System.EventHandler(this.numDPI_ValueChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comUnits
            // 
            this.comUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comUnits.FormattingEnabled = true;
            resources.ApplyResources(this.comUnits, "comUnits");
            this.comUnits.Name = "comUnits";
            this.comUnits.SelectedIndexChanged += new System.EventHandler(this.comUnits_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkHelp);
            this.groupBox1.Controls.Add(this.butSubmit);
            this.groupBox1.Controls.Add(this.numScaling);
            this.groupBox1.Controls.Add(this.numDPI);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label11);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
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
            // CalibrationForm
            // 
            this.AcceptButton = this.butSubmit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comUnits);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalibrationForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.CalibrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numScaling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDPI)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.NumericUpDown numScaling;
        private System.Windows.Forms.NumericUpDown numDPI;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comUnits;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button butSubmit;
        private System.Windows.Forms.LinkLabel lnkHelp;
    }
}