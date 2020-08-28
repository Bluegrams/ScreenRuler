namespace ScreenRuler
{
    partial class CustomLineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomLineForm));
            this.lblLine = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.lblDirection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLine
            // 
            resources.ApplyResources(this.lblLine, "lblLine");
            this.lblLine.Name = "lblLine";
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.butCancel, "butCancel");
            this.butCancel.Name = "butCancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butDelete
            // 
            resources.ApplyResources(this.butDelete, "butDelete");
            this.butDelete.Name = "butDelete";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // lblDirection
            // 
            resources.ApplyResources(this.lblDirection, "lblDirection");
            this.lblDirection.Name = "lblDirection";
            // 
            // CustomLineForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.lblLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomLineForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Label lblDirection;
    }
}