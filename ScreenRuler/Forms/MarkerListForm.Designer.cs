using ScreenRuler.Controls;

namespace ScreenRuler
{
    partial class MarkerListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarkerListForm));
            this.lstMarkers = new ScreenRuler.Controls.MarkerListBox();
            this.contxtListMarkers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contxtListMarkers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMarkers
            // 
            resources.ApplyResources(this.lstMarkers, "lstMarkers");
            this.lstMarkers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMarkers.ContextMenuStrip = this.contxtListMarkers;
            this.lstMarkers.DisplayMember = "DisplayString";
            this.lstMarkers.FormattingEnabled = true;
            this.lstMarkers.Name = "lstMarkers";
            this.lstMarkers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstMarkers.Sorted = true;
            this.lstMarkers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstMarkers_MouseDoubleClick);
            // 
            // contxtListMarkers
            // 
            resources.ApplyResources(this.contxtListMarkers, "contxtListMarkers");
            this.contxtListMarkers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conDelete});
            this.contxtListMarkers.Name = "contxtListMarkers";
            // 
            // conDelete
            // 
            resources.ApplyResources(this.conDelete, "conDelete");
            this.conDelete.Name = "conDelete";
            this.conDelete.Click += new System.EventHandler(this.conDelete_Click);
            // 
            // MarkerListForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstMarkers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarkerListForm";
            this.contxtListMarkers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MarkerListBox lstMarkers;
        private System.Windows.Forms.ContextMenuStrip contxtListMarkers;
        private System.Windows.Forms.ToolStripMenuItem conDelete;
    }
}