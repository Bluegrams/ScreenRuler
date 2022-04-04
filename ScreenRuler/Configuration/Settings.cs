using System;
using ScreenRuler.Colors;
using ScreenRuler.Units;

namespace ScreenRuler.Configuration
{
    [Serializable]
    public class Settings
    {
        /// <summary>
        /// Determines whether only a slim ruler scale should be shown.
        /// </summary>
        public bool SlimMode { get; set; }
        /// <summary>
        /// The currently selected measuring unit.
        /// </summary>
        public MeasuringUnit MeasuringUnit { get; set; }
        /// <summary>
        /// Determines how to the scale the ruler based on the monitor's DPI and scaling.
        /// </summary>
        public DpiScalingMode DpiScalingMode { get; set; }
        /// <summary>
        /// Manual setting for the monitor's DPI. Only used with DpiScalingMode.Manual.
        /// </summary>
        public float MonitorDpi { get; set; } = 96;
        /// <summary>
        /// Manual setting for the monitor's vertical DPI. Only used with DpiScalingMode.ManualBidirectional.
        /// </summary>
        public float VerticalMonitorDpi { get; set; } = 96;
        /// <summary>
        /// Determines whether the center of the ruler should be marked.
        /// </summary>
        public bool ShowCenterLine { get; set; }
        /// <summary>
        /// Determines whether the thirds of the ruler should be marked.
        /// </summary>
        public bool ShowThirdLines { get; set; }
        /// <summary>
        /// Determines whether the Golden Ratio should be marked on the ruler.
        /// </summary>
        public bool ShowGoldenLine { get; set; }
        /// <summary>
        /// Determines whether the position of the cursor should be marked.
        /// </summary>
        public bool ShowMouseLine { get; set; } = true;
        /// <summary>
        /// Specifies if and how to draw the hypotenuse of the triangle defined by the mouse markers if the ruler is in 2D mode.
        /// </summary>
        public HypotenuseMode HypotenuseMode { get; set; } = HypotenuseMode.None;
        /// <summary>
        /// If set to true, ruler scale and custom markings are not drawn.
        /// </summary>
        public bool HideRulerScale { get; set; } = false;
        /// <summary>
        /// Defines the thickness (in pixels) of one marking line.
        /// </summary>
        public byte MarkerThickness { get; set; } = 1;
        /// <summary>
        /// Determines if multiple markings are allowed.
        /// </summary>
        public bool MultiMarking { get; set; } = true;
        /// <summary>
        /// Determines whether labels for the ruler offset and length are shown.
        /// </summary>
        public bool ShowOffsetLengthLabels { get; set; } = true;
        /// <summary>
        /// Determines whether to show the tool tip.
        /// </summary>
        public bool ShowToolTip { get; set; } = true;
        /// <summary>
        /// Determines whether to show a symbol for markers
        /// </summary>
        public bool ShowMarkerSymbol { get; set; } = false;
        /// <summary>
        /// Determines whether to use a notify icon instead of showing window in task bar.
        /// </summary>
        public bool UseNotifyIcon { get; set; } = true;
        /// <summary>
        /// Determines whether the ruler should follow the mouse pointer.
        /// </summary>
        public bool FollowMousePointer { get; set; } = false;
        /// <summary>
        /// If set to true, the center point of the ruler will follow the mouse pointer; otherwise left upper corner will be attached. 
        /// </summary>
        public bool FollowMousePointerCenter { get; set; } = true;
        /// <summary>
        /// If set to true, will snap the ruler to screen edges.
        /// </summary>
        public bool SnapToScreenEdges { get; set; } = false;

        private ThemeOption selectedTheme;

        /// <summary>
        /// This event is raised whenever the selected theme option has changed.
        /// </summary>
        public event EventHandler SelectedThemeChanged;

        /// <summary>
        /// The currently selected theme option.
        /// </summary>
        public ThemeOption SelectedTheme
        {
            get { return selectedTheme; }
            set
            {
                selectedTheme = value;
                switch (value)
                {
                    case ThemeOption.Light:
                        Theme = CommonThemes.LightTheme;
                        break;
                    case ThemeOption.Dark:
                        Theme = CommonThemes.DarkTheme;
                        break;
                }
                SelectedThemeChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// The currently selected theme (influenced by SelectedTheme).
        /// </summary>
        public Theme Theme { get; set; } = CommonThemes.LightTheme;

        /// <summary>
        /// Defines the size of one small ruler moving/ resizing step.
        /// </summary>
        public int SmallStep { get; set; } = 1;
        /// <summary>
        /// Defines the size of one medium ruler resizing step.
        /// </summary>
        public int MediumStep { get; set; } = 5;
        /// <summary>
        /// Defines the size of one big ruler resizing step.
        /// </summary>
        public int LargeStep { get; set; } = 25;


        /// <summary>
        /// Specifies the horizontal and vertical ruler flipping.
        /// </summary>
        public RulerTransform RulerTransform { get; set; } = RulerTransform.None;
        public bool FlippedX => RulerTransform.HasFlag(RulerTransform.FlippedX);
        public bool FlippedY => RulerTransform.HasFlag(RulerTransform.FlippedY);


        /// <summary>
        /// An event that allows to explicitly inform users of this class about changes.
        /// </summary>
        public event EventHandler Changed;

        /// <summary>
        /// Invoke the Changed event.
        /// </summary>
        public void InvokeChanged() => Changed?.Invoke(this, EventArgs.Empty);

        public Settings Clone() => (Settings)this.MemberwiseClone();
    }
}
