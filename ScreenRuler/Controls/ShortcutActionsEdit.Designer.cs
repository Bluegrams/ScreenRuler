
namespace ScreenRuler.Controls
{
    partial class ShortcutActionsEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortcutActionsEdit));
            this.lstShortcuts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butReset = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.contxtMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.conReset = new System.Windows.Forms.ToolStripMenuItem();
            this.conClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contxtMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstShortcuts
            // 
            resources.ApplyResources(this.lstShortcuts, "lstShortcuts");
            this.lstShortcuts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstShortcuts.ContextMenuStrip = this.contxtMain;
            this.lstShortcuts.FullRowSelect = true;
            this.lstShortcuts.GridLines = true;
            this.lstShortcuts.HideSelection = false;
            this.lstShortcuts.MultiSelect = false;
            this.lstShortcuts.Name = "lstShortcuts";
            this.lstShortcuts.UseCompatibleStateImageBehavior = false;
            this.lstShortcuts.View = System.Windows.Forms.View.Details;
            this.lstShortcuts.SelectedIndexChanged += new System.EventHandler(this.lstShortcuts_SelectedIndexChanged);
            this.lstShortcuts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstShortcuts_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // butReset
            // 
            resources.ApplyResources(this.butReset, "butReset");
            this.butReset.Name = "butReset";
            this.butReset.UseVisualStyleBackColor = true;
            this.butReset.Click += new System.EventHandler(this.butReset_Click);
            // 
            // butEdit
            // 
            resources.ApplyResources(this.butEdit, "butEdit");
            this.butEdit.Name = "butEdit";
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // lblShortcut
            // 
            resources.ApplyResources(this.lblShortcut, "lblShortcut");
            this.lblShortcut.Name = "lblShortcut";
            // 
            // contxtMain
            // 
            this.contxtMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conEdit,
            this.conReset,
            this.toolStripSeparator1,
            this.conClear});
            this.contxtMain.Name = "contxtMain";
            resources.ApplyResources(this.contxtMain, "contxtMain");
            // 
            // conEdit
            // 
            this.conEdit.Name = "conEdit";
            resources.ApplyResources(this.conEdit, "conEdit");
            this.conEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // conReset
            // 
            this.conReset.Name = "conReset";
            resources.ApplyResources(this.conReset, "conReset");
            this.conReset.Click += new System.EventHandler(this.butReset_Click);
            // 
            // conClear
            // 
            this.conClear.Name = "conClear";
            resources.ApplyResources(this.conClear, "conClear");
            this.conClear.Click += new System.EventHandler(this.conClear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // ShortcutActionsEdit
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblShortcut);
            this.Controls.Add(this.butEdit);
            this.Controls.Add(this.butReset);
            this.Controls.Add(this.lstShortcuts);
            this.Name = "ShortcutActionsEdit";
            this.contxtMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstShortcuts;
        private System.Windows.Forms.Button butReset;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblShortcut;
        private System.Windows.Forms.ContextMenuStrip contxtMain;
        private System.Windows.Forms.ToolStripMenuItem conClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem conEdit;
        private System.Windows.Forms.ToolStripMenuItem conReset;
    }
}
