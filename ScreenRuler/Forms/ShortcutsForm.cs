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
    }
}
