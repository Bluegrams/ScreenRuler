using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ScreenRuler.Configuration;
using Shortcut = ScreenRuler.Configuration.Shortcut;

namespace ScreenRuler.Controls
{
    [ProvideProperty("ShortcutAction", typeof(ToolStripMenuItem))]
    public partial class ShortcutActions : Component, IExtenderProvider
    {
        private readonly Dictionary<ActionCode, Shortcut> shortcuts = new Dictionary<ActionCode, Shortcut>();
        private readonly Dictionary<ToolStripMenuItem, ActionCode> controlMap = new Dictionary<ToolStripMenuItem, ActionCode>();

        public ShortcutActions()
        {
            InitializeComponent();
            SetShortcuts(Shortcuts.DefaultShortcuts.ToArray());
        }

        public ShortcutActions(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            SetShortcuts(Shortcuts.DefaultShortcuts.ToArray());
        }

        public Shortcut this[ActionCode action]
        {
            get => shortcuts[action];
        }

        public ICollection<Shortcut> GetShortcuts()
        {
            return shortcuts.Values;
        }

        public void SetShortcuts(params Shortcut[] shortcuts)
        {
            if (shortcuts == null)
                return;
            foreach (Shortcut shortcut in shortcuts)
            {
                if (this.shortcuts.ContainsKey(shortcut.Action))
                    this.shortcuts[shortcut.Action] = shortcut;
                else
                    this.shortcuts.Add(shortcut.Action, shortcut);
            }
            InvokeChanged();
        }

        public ActionCode HandleInput(Keys keys)
        {
            // Retrieve action code
            ActionCode action = GetShortcuts()
                .Where(s => s.Keys == keys)
                .Select(s => s.Action)
                .FirstOrDefault();
            // Invoke control if applicable
            ToolStripMenuItem control = controlMap
                .Where(kv => kv.Value == action)
                .Select(kv => kv.Key)
                .Where(c => c.ShortcutKeys == Keys.None)
                .FirstOrDefault();
            if (control != null)
            {
                control.PerformClick();
                return ActionCode.None;
            }
            else
            {
                return action;
            }
        }

        public bool CanExtend(object extendee)
        {
            return extendee is ToolStripMenuItem;
        }

        [DisplayName("ShortcutAction")]
        [DefaultValue(ActionCode.None)]
        [ExtenderProvidedProperty]
        public ActionCode GetShortcutAction(ToolStripMenuItem extendee)
        {
            if (controlMap.ContainsKey(extendee))
            {
                return controlMap[extendee];
            }
            else
            {
                return ActionCode.None;
            }
        }

        public void SetShortcutAction(ToolStripMenuItem extendee, ActionCode action)
        {
            if (action == ActionCode.None)
            {
                if (controlMap.Remove(extendee))
                {
                    extendee.ShortcutKeys = Keys.None;
                }
            }
            else
            {
                controlMap[extendee] = action;
                applyShortcutToControl(extendee, action);
            }
        }

        public void InvokeChanged()
        {
            foreach (var item in controlMap)
            {
                applyShortcutToControl(item.Key, item.Value);
            }
        }

        private void applyShortcutToControl(ToolStripMenuItem item, ActionCode action)
        {
            Shortcut shortcut = shortcuts[action];
            if (ToolStripManager.IsValidShortcut(shortcut.Keys))
            {
                item.ShortcutKeys = shortcut.Keys;
                item.ShortcutKeyDisplayString = shortcut.KeysString;
            }
            else
            {
                item.ShortcutKeys = Keys.None;
                item.ShortcutKeyDisplayString = shortcut.KeysString;
            }
        }
    }
}
