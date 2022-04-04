using ScreenRuler.Configuration;
using System;
using System.Windows.Forms;
using Bluegrams.Windows.Tools;
using Shortcut = ScreenRuler.Configuration.Shortcut;

namespace ScreenRuler.Controls
{
    public partial class ShortcutActionsEdit : UserControl
    {
        public ShortcutActions ShortcutActions { get; private set; } 

        public ShortcutActionsEdit()
        {
            InitializeComponent();
        }

        public void LoadShortcutActions(ShortcutActions shortcutActions)
        {
            ShortcutActions = shortcutActions;
            // Fill shortcuts
            foreach (Shortcut shortcut in shortcutActions.GetShortcuts())
            {
                lstShortcuts.Items.Add(new ListViewItem(shortcut.ToStringArray()) { Tag = shortcut.Action });
            }
        }

        private void lstShortcuts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstShortcuts.SelectedItems.Count > 0)
            {
                lblShortcut.Text = lstShortcuts.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                lblShortcut.Text = String.Empty;
            }
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            editShortcut(lstShortcuts.SelectedItems[0]);
        }

        private void lstShortcuts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = lstShortcuts.HitTest(e.Location);
            if (hit.Item != null)
            {
                editShortcut(hit.Item);
            }
        }

        private void butReset_Click(object sender, EventArgs e)
        {
            ActionCode action = (ActionCode)lstShortcuts.SelectedItems[0].Tag;
            Shortcut shortcut = new Shortcut(action, Shortcuts.GetDefaultKeys(action));
            ShortcutActions.SetShortcuts(shortcut);
            applyShortcutChange(lstShortcuts.SelectedItems[0], shortcut);
        }

        private void conClear_Click(object sender, EventArgs e)
        {
            ActionCode action = (ActionCode)lstShortcuts.SelectedItems[0].Tag;
            Shortcut shortcut = new Shortcut(action, Keys.None);
            ShortcutActions.SetShortcuts(shortcut);
            applyShortcutChange(lstShortcuts.SelectedItems[0], shortcut);
        }

        private void editShortcut(ListViewItem selectedItem)
        {
            ActionCode action = (ActionCode)selectedItem.Tag;
            HotKeyInputForm hotKeyInputForm = new HotKeyInputForm(ShortcutActions[action].Keys)
            {
                DescriptionText = selectedItem.SubItems[0].Text,
                ModifiersRequired = false,
            };
            if (hotKeyInputForm.ShowDialog() == DialogResult.OK)
            {
                Shortcut shortcut = new Shortcut(action, hotKeyInputForm.SelectedKeys);
                ShortcutActions.SetShortcuts(shortcut);
                applyShortcutChange(selectedItem, shortcut);
            }
        }

        private void applyShortcutChange(ListViewItem item, Shortcut shortcut)
        {
            string[] stringArray = shortcut.ToStringArray();
            for (int i = 0; i < stringArray.Length; i++)
            {
                item.SubItems[i] = new ListViewItem.ListViewSubItem(item, stringArray[i]);
            }
            item.Tag = shortcut.Action;
            lblShortcut.Text = shortcut.KeysString;
            this.Invalidate();
        }
    }
}
