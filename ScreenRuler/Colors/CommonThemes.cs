using System;
using System.Drawing;

namespace ScreenRuler.Colors
{
    public enum ThemeOption
    {
        Light = 0,
        Dark = 1,
        Custom = 2
    }

    public static class CommonThemes
    {
        /// <summary>
        /// The default light theme.
        /// </summary>
        public static Theme LightTheme = new Theme()
        {
            Background = Color.White,
            TickColor = Color.Black,
            LengthLabelColor = Color.Green,
            CenterLineColor = Color.Blue,
            MouseLineColor = Color.Orange,
            ThirdsLinesColor = Color.DeepSkyBlue,
            CustomLinesColor = Color.Red
        };

        /// <summary>
        /// The default dark theme.
        /// </summary>
        public static Theme DarkTheme = new Theme()
        {
            Background = Color.FromArgb(16, 16, 16),
            TickColor = Color.White,
            LengthLabelColor = Color.White,
            CenterLineColor = Color.Fuchsia,
            MouseLineColor = Color.Orange,
            ThirdsLinesColor = Color.DarkTurquoise,
            CustomLinesColor = Color.OrangeRed
        };
    }
}
