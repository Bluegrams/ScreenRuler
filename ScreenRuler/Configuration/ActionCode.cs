using System;
using ScreenRuler.Properties;

namespace ScreenRuler.Configuration
{
    /// <summary>
    /// Defines possible keyboard actions of the app.
    /// Mappings from action codes to keys in DefaultShortcuts dict in Configuration/Shortcuts.cs.
    /// </summary>
    public enum ActionCode
    {
        // No action
        None,
        // Ruler modes
        [LocalizedDescription("Actions_ToggleRulerMode", typeof(EnumResources))]
        ToggleRulerMode,
        [LocalizedDescription("Actions_ToggleVertical", typeof(EnumResources))]
        ToggleVertical,
        [LocalizedDescription("conFlipVertically.Text", typeof(RulerForm))]
        FlipVertically,
        [LocalizedDescription("conFlipHorizontally.Text", typeof(RulerForm))]
        FlipHorizontally,
        [LocalizedDescription("Actions_ToggleSlimMode", typeof(EnumResources))]
        ToggleSlimMode,
        [LocalizedDescription("Actions_ToggleHypotenuseMode", typeof(EnumResources))]
        ToggleHypotenuseMode,
        [LocalizedDescription("conFollowMousePointer.Text", typeof(RulerForm))]
        ToggleFollowMouseMode,
        // Tools
        [LocalizedDescription("conMeasure.Text", typeof(RulerForm))]
        MeasureWindow,
        [LocalizedDescription("Actions_CopySize", typeof(EnumResources))]
        CopySize,
        [LocalizedDescription("conLength.Text", typeof(RulerForm))]
        SetSize,
        // Appearance
        [LocalizedDescription("conTopmost.Text", typeof(RulerForm))]
        PinTop,
        [LocalizedDescription("conMinimize.Text", typeof(RulerForm))]
        Minimize,
        [LocalizedDescription("Actions_ToggleTheme", typeof(EnumResources))]
        ToggleTheme,
        [LocalizedDescription("Actions_IncreaseOpacity", typeof(EnumResources))]
        IncreaseOpacity,
        [LocalizedDescription("Actions_DecreaseOpacity", typeof(EnumResources))]
        DecreaseOpacity,
        [LocalizedDescription("conHideRulerScale.Text", typeof(RulerForm))]
        HideRulerScale,
        // Markers
        [LocalizedDescription("conMarkCenter.Text", typeof(RulerForm))]
        MarkCenter,
        [LocalizedDescription("conMarkThirds.Text", typeof(RulerForm))]
        MarkThirds,
        [LocalizedDescription("conMarkGolden.Text", typeof(RulerForm))]
        MarkGoldenRatio,
        [LocalizedDescription("conMarkMouse.Text", typeof(RulerForm))]
        MarkMouse,
        [LocalizedDescription("conEditMarkers.Text", typeof(RulerForm))]
        EditMarkers,
        [LocalizedDescription("conClearCustomMarker.Text", typeof(RulerForm))]
        ClearAllMarkers,
        [LocalizedDescription("Actions_DeleteFirstMarker", typeof(EnumResources))]
        DeleteFirstMarker,
        [LocalizedDescription("Actions_AddMarkerAtCurrent", typeof(EnumResources))]
        AddMarkerAtCurrent,
        [LocalizedDescription("Actions_AddMarkerAtLength", typeof(EnumResources))]
        AddMarkerAtLength,
        // Others
        [LocalizedDescription("conSettings.Text", typeof(RulerForm))]
        Settings,
        [LocalizedDescription("conShortcuts.Text", typeof(RulerForm))]
        ConfigureShortcuts,
        [LocalizedDescription("conCalibrate.Text", typeof(RulerForm))]
        CalibrateRuler,
        [LocalizedDescription("conHelp.Text", typeof(RulerForm))]
        ShowHelp,
        [LocalizedDescription("conExit.Text", typeof(RulerForm))]
        ExitApp,
    }
}
