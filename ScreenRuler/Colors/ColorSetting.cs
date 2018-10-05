using System;
using System.Drawing;
using System.Xml.Serialization;

namespace ScreenRuler.Colors
{
    /// <summary>
    /// Wraps System.Drawing.Color into a serializable object.
    /// </summary>
    [Serializable]
    public class ColorSetting
    {
        public ColorSetting() { }

        public ColorSetting(Color color)
        {
            this.Color = color;
        }

        [XmlIgnore]
        public Color Color { get; set; }

        [XmlText]
        public string HexCode
        {
            get { return ToString(); }
            set { Color = ColorTranslator.FromHtml(value); }
        }

        public override string ToString()
        {
            return String.Format("#{0}{1}{2}", Color.R.ToString("X2"),
                Color.G.ToString("X2"), Color.B.ToString("X2"));
        }

        public static implicit operator Color(ColorSetting colorSetting)
        {
            return colorSetting.Color;
        }

        public static implicit operator ColorSetting(Color color)
        {
            return new ColorSetting(color);
        }
    }
}
