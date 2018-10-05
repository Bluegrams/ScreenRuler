namespace ScreenRuler
{
    partial class SetSizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetSizeForm));
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butSubmit = new System.Windows.Forms.Button();
            this.comUnits = new System.Windows.Forms.ComboBox();
            this.lblUnitString = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLength
            // 
            resources.ApplyResources(this.txtLength, "txtLength");
            this.txtLength.Name = "txtLength";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.butCancel, "butCancel");
            this.butCancel.Name = "butCancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butSubmit
            // 
            resources.ApplyResources(this.butSubmit, "butSubmit");
            this.butSubmit.Name = "butSubmit";
            this.butSubmit.UseVisualStyleBackColor = true;
            this.butSubmit.Click += new System.EventHandler(this.butSubmit_Click);
            // 
            // comUnits
            // 
            this.comUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comUnits.FormattingEnabled = true;
            resources.ApplyResources(this.comUnits, "comUnits");
            this.comUnits.Name = "comUnits";
            this.comUnits.SelectedIndexChanged += new System.EventHandler(this.comUnits_SelectedIndexChanged);
            // 
            // lblUnitString
            // 
            resources.ApplyResources(this.lblUnitString, "lblUnitString");
            this.lblUnitString.Name = "lblUnitString";
            // 
            // SetSizeForm
            // 
            this.AcceptButton = this.butSubmit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.Controls.Add(this.lblUnitString);
            this.Controls.Add(this.comUnits);
            this.Controls.Add(this.butSubmit);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLength);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetSizeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SetSizeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSubmit;
        private System.Windows.Forms.ComboBox comUnits;
        private System.Windows.Forms.Label lblUnitString;
    }
}