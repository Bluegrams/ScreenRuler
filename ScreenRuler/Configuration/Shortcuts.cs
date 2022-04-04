using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ScreenRuler.Configuration
{
    /// <summary>
    /// Represents a mapping from application action to shortcut keys.
    /// </summary>
    [Serializable]
    public class Shortcut
    {
        public ActionCode Action { get; set; }
        [XmlIgnore]
        public Keys Keys { get; set; }

        // TODO: KeysConverter is unable to convert to/from invariant culture strings.
        // See https://stackoverflow.com/q/61331395/9145461 and https://github.com/dotnet/winforms/issues/2886.
        // Therefore, this property is used for serialization to settings,
        // meaning that custom shortcuts are NOT preserved when changing the app language.
        [XmlElement(ElementName="Keys")]
        public string KeysString
        {
            get
            {
                KeysConverter keysConverter = new KeysConverter();
                string keysString = keysConverter.ConvertToString(Keys);
                // Replace some special chars to make string more readable
                keysString = keysString.Replace("Oemcomma", ",").Replace("OemPeriod", ".").Replace("None", "");
                return keysString;
            }
            set
            {
                KeysConverter keysConverter = new KeysConverter();
                string keysString = value.Replace(",", "Oemcomma").Replace(".", "OemPeriod");
                if (String.IsNullOrEmpty(keysString))
                    keysString = "None";
                Keys = (Keys)keysConverter.ConvertFromString(keysString);
            }
        }

        public Shortcut()
        { }

        public Shortcut(ActionCode action, Keys keys)
        {
            this.Action = action;
            this.Keys = keys;
        }

        public override string ToString() => $"{Action}: {Keys}";

        public string[] ToStringArray()
        {
            return new[] { Action.GetDescription(), KeysString };
        }
    }

    public static class Shortcuts
    {
        public static List<Shortcut> DefaultShortcuts = new List<Shortcut>()
        {
            // Ruler modes
            new Shortcut(ActionCode.ToggleRulerMode, Keys.Space),
            new Shortcut(ActionCode.ToggleVertical, Keys.V),
            new Shortcut(ActionCode.FlipVertically, Keys.Shift | Keys.F),
            new Shortcut(ActionCode.FlipHorizontally, Keys.F),
            new Shortcut(ActionCode.ToggleSlimMode, Keys.J),
            new Shortcut(ActionCode.ToggleHypotenuseMode, Keys.H),
            new Shortcut(ActionCode.ToggleFollowMouseMode, Keys.W),
            // Tools
            new Shortcut(ActionCode.MeasureWindow, Keys.Z),
            new Shortcut(ActionCode.CopySize, Keys.Control | Keys.C),
            new Shortcut(ActionCode.SetSize, Keys.Control | Keys.L),
            // Appearance
            new Shortcut(ActionCode.PinTop, Keys.S),
            new Shortcut(ActionCode.Minimize, Keys.Control | Keys.M),
            new Shortcut(ActionCode.ToggleTheme, Keys.Control | Keys.T),
            new Shortcut(ActionCode.IncreaseOpacity, Keys.Control | Keys.Oemplus),
            new Shortcut(ActionCode.DecreaseOpacity, Keys.Control | Keys.OemMinus),
            new Shortcut(ActionCode.HideRulerScale, Keys.Control | Keys.H),
            // Markers
            new Shortcut(ActionCode.MarkCenter, Keys.M),
            new Shortcut(ActionCode.MarkThirds, Keys.T),
            new Shortcut(ActionCode.MarkGoldenRatio, Keys.G),
            new Shortcut(ActionCode.MarkMouse, Keys.P),
            new Shortcut(ActionCode.EditMarkers, Keys.Control | Keys.E),
            new Shortcut(ActionCode.ClearAllMarkers, Keys.Delete),
            new Shortcut(ActionCode.DeleteFirstMarker, Keys.C),
            new Shortcut(ActionCode.AddMarkerAtCurrent, Keys.X),
            new Shortcut(ActionCode.AddMarkerAtLength, Keys.L),
            // Others
            new Shortcut(ActionCode.Settings, Keys.Control | Keys.Oemcomma),
            new Shortcut(ActionCode.ConfigureShortcuts, Keys.Control | Keys.Shift | Keys.Oemcomma),
            new Shortcut(ActionCode.CalibrateRuler, Keys.Control | Keys.K),
            new Shortcut(ActionCode.ShowHelp, Keys.F1),
            new Shortcut(ActionCode.ExitApp, Keys.Escape),
        };

        /// <summary>
        /// Gets the default shortcut keys for a given action.
        /// </summary>
        /// <param name="action">The action for which to retrieve shortcut keys.</param>
        /// <returns>The corresponding default shortcut keys.</returns>
        public static Keys GetDefaultKeys(ActionCode action)
        {
            return DefaultShortcuts.Where(s => s.Action == action).Select(s => s.Keys).FirstOrDefault();
        }
    }
}
