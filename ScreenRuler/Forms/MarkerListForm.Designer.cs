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
            this.conUnits = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.conDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contxtListMarkers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMarkers
            // 
            this.lstMarkers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMarkers.ContextMenuStrip = this.contxtListMarkers;
            this.lstMarkers.DisplayMember = "DisplayString";
            resources.ApplyResources(this.lstMarkers, "lstMarkers");
            this.lstMarkers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstMarkers.FormattingEnabled = true;
            this.lstMarkers.Name = "lstMarkers";
            this.lstMarkers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstMarkers.Sorted = true;
            this.lstMarkers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstMarkers_MouseDoubleClick);
            // 
            // contxtListMarkers
            // 
            this.contxtListMarkers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conUnits,
            this.toolStripSeparator1,
            this.conDelete});
            this.contxtListMarkers.Name = "contxtListMarkers";
            resources.ApplyResources(this.contxtListMarkers, "contxtListMarkers");
            // 
            // conUnits
            // 
            this.conUnits.Name = "conUnits";
            resources.ApplyResources(this.conUnits, "conUnits");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // conDelete
            // 
            this.conDelete.Name = "conDelete";
            resources.ApplyResources(this.conDelete, "conDelete");
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MarkerListForm_FormClosed);
            this.DpiChanged += new System.Windows.Forms.DpiChangedEventHandler(this.MarkerListForm_DpiChanged);
            this.contxtListMarkers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MarkerListBox lstMarkers;
        private System.Windows.Forms.ContextMenuStrip contxtListMarkers;
        private System.Windows.Forms.ToolStripMenuItem conDelete;
        private System.Windows.Forms.ToolStripMenuItem conUnits;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}