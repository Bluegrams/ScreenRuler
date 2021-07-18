using System;
using ScreenRuler.Properties;
using ScreenRuler.Units;

namespace ScreenRuler
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
}
