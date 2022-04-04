using System;
using ScreenRuler.Properties;

namespace ScreenRuler.Configuration
{
    public enum HypotenuseMode
    {
        [LocalizedDescription("HypotenuseMode_None", typeof(EnumResources))]
        None = 0,
        [LocalizedDescription("HypotenuseMode_FixedAtLength", typeof(EnumResources))]
        FixedAtLength = 1,
        [LocalizedDescription("HypotenuseMode_Moving", typeof(EnumResources))]
        Moving = 2,
    }

    [Flags]
    public enum RulerTransform
    {
        None = 0,
        FlippedX = 1,
        FlippedY = 2,
        CornerUpperLeft = None,
        CornerUpperRight = FlippedX,
        CornerLowerLeft = FlippedY,
        CornerLowerRight = FlippedX | FlippedY,
    }

    public enum DpiScalingMode
    {
        [LocalizedDescription("DpiScalingMode_Unaware", typeof(EnumResources))]
        Unaware = 0,
        [LocalizedDescription("DpiScalingMode_Auto", typeof(EnumResources))]
        Auto = 1,
        [LocalizedDescription("DpiScalingMode_Manual", typeof(EnumResources))]
        Manual = 2,
        [LocalizedDescription("DpiScalingMode_ManualBidirectional", typeof(EnumResources))]
        ManualBidirectional = 3,
    }
}
