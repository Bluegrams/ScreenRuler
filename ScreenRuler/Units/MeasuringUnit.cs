using ScreenRuler.Properties;

namespace ScreenRuler.Units
{
    /// <summary>
    /// Possible measuring units used for the user scale.
    /// </summary>
    public enum MeasuringUnit
    {
        [LocalizedDescription("Pixels", typeof(EnumResources))]
        Pixels = 0,
        [LocalizedDescription("Centimeters", typeof(EnumResources))]
        Centimeters = 1,
        [LocalizedDescription("Inches", typeof(EnumResources))]
        Inches = 2,
        [LocalizedDescription("Points", typeof(EnumResources))]
        Points = 3,
        [LocalizedDescription("Percent", typeof(EnumResources))]
        Percent = 4
    }
}
