using System;
using System.Windows.Forms;
using ScreenRuler.Controls;

namespace ScreenRuler
{
    public partial class ShortcutsForm : Form
    {
        public ShortcutsForm(ShortcutActions shortcutActions)
        {
            InitializeComponent();
            shortcutActionsEdit.LoadShortcutActions(shortcutActions);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
