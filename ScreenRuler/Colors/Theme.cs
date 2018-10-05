using System;

namespace ScreenRuler.Colors
{
    /// <summary>
    /// A collection of colors that specify the appearance of the ruler.
    /// </summary>
    [Serializable]
    public class Theme
    {
        /// <summary>
        /// The background color of the ruler.
        /// </summary>
        public ColorSetting Background { get; set; }
        /// <summary>
        /// The color of the ticks on the ruler scale.
        /// </summary>
        public ColorSetting TickColor { get; set; }
        /// <summary>
        /// The color of the label that shows the total length of the ruler.
        /// </summary>
        public ColorSetting LengthLabelColor { get; set; }
        /// <summary>
        /// The color of the marker that indicates the cursor position.
        /// </summary>
        public ColorSetting MouseLineColor { get; set; }
        /// <summary>
        /// The color of the marker that indicates the center of the ruler.
        /// </summary>
        public ColorSetting CenterLineColor { get; set; }
        /// <summary>
        /// The color of the markers that divide the ruler into three parts.
        /// </summary>
        public ColorSetting ThirdsLinesColor { get; set; }
        /// <summary>
        /// The color of custom markers.
        /// </summary>
        public ColorSetting CustomLinesColor { get; set; }
    }
}
