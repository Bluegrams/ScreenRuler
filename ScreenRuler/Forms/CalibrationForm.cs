using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using ScreenRuler.Configuration;
using ScreenRuler.Units;

namespace ScreenRuler
{
    public partial class CalibrationForm : Form
    {
        private Settings currentSettings, originalSettings;

        public DpiScalingMode DpiScalingMode { get; private set; }
        public float MonitorDpi { get; private set; }
        public float VerticalMonitorDpi { get; private set; }
        public MeasuringUnit MeasuringUnit { get; private set; }

        public event EventHandler CalibrationChanged;

        public CalibrationForm(Settings settings)
        {

            InitializeComponent();
            setFromSettings(settings);
            this.currentSettings = settings;
            this.originalSettings = settings.Clone();
        }

        private void CalibrationForm_Load(object sender, EventArgs e)
        {
            // --- Set scaling settings ---
            foreach (Enum item in Enum.GetValues(typeof(DpiScalingMode)))
            {
                comDpiScalingMode.Items.Add(item.GetDescription());
            }
            comDpiScalingMode.SelectedIndex = (int)DpiScalingMode;
            applyDpiScalingMode();
            var items = Enum.GetValues(typeof(MeasuringUnit))
                .Cast<Enum>()
                .Where(item => (MeasuringUnit)item != MeasuringUnit.Pixels && (MeasuringUnit)item != MeasuringUnit.Percent)
                .Select(item => new { Text = item.GetDescription(), Value = item })
                .ToList();
            comUnits.DataSource = items;
            comUnits.SelectedValue = this.originalSettings.MeasuringUnit;
            // Set a default value if current measuring unit is not in supported values
            if (comUnits.SelectedValue == null)
            {
                comUnits.SelectedValue = items[0].Value;
            }
            // --- Owner events & settings ---
            this.Owner.Move += Owner_Move;
            this.Owner.Resize += Owner_Resize;
            ((BaseForm)this.Owner).ResizeModeChanged += Owner_ResizeModeChanged;
            setResizeMode(((BaseForm)this.Owner).ResizeMode);
        }

        private void Owner_Move(object sender, EventArgs e)
        {
            if (DpiScalingMode == DpiScalingMode.Manual || DpiScalingMode == DpiScalingMode.ManualBidirectional)
                applyDpiFromSettings();
        }

        private void Owner_Resize(object sender, EventArgs e)
        {
            applyUnitFromSettings();
        }

        private void Owner_ResizeModeChanged(object sender, ResizeModeEventArgs e)
        {
            setResizeMode(e.NewResizeMode);
        }

        private void setFromSettings(Settings settings)
        {
            DpiScalingMode = settings.DpiScalingMode;
            MonitorDpi = settings.MonitorDpi;
            VerticalMonitorDpi = settings.VerticalMonitorDpi;
        }

        private void setResizeMode(FormResizeMode resizeMode)
        {
            switch (resizeMode)
            {
                case FormResizeMode.Horizontal:
                    numUnitH.Enabled = true;
                    numUnitV.Enabled = false;
                    break;
                case FormResizeMode.Vertical:
                    numUnitH.Enabled = false;
                    numUnitV.Enabled = true;
                    break;
                case FormResizeMode.TwoDimensional:
                    numUnitH.Enabled = true;
                    numUnitV.Enabled = true;
                    break;
            }
        }

        private void invokeCalibrationChanged()
        {
            currentSettings.DpiScalingMode = DpiScalingMode;
            currentSettings.MonitorDpi = MonitorDpi;
            currentSettings.VerticalMonitorDpi = VerticalMonitorDpi;
            currentSettings.InvokeChanged();
            CalibrationChanged?.Invoke(this, EventArgs.Empty);
        }

        private void applyDpiFromSettings()
        {
            // Temporarily unregister event handlers of controls to avoid loop.
            numDpiH.ValueChanged -= numDpiH_ValueChanged;
            numDpiV.ValueChanged -= numDpiV_ValueChanged;
            var dpi = UnitConverter.GetDpiFromSettings(this, currentSettings);
            numDpiH.Value = (decimal)dpi.horizontal;
            numDpiV.Value = (decimal)(dpi.vertical ?? dpi.horizontal);
            // Re-register event handlers
            numDpiH.ValueChanged += numDpiH_ValueChanged;
            numDpiV.ValueChanged += numDpiV_ValueChanged;
        }

        private void applyUnitFromSettings()
        {
            // Temporarily unregister event handlers of controls to avoid loop.
            numUnitH.ValueChanged -= numUnitH_ValueChanged;
            numUnitV.ValueChanged -= numUnitV_ValueChanged;
            UnitConverter converter = UnitConverter.FromSettings(Owner, currentSettings, MeasuringUnit);
            numUnitH.Value = (decimal)converter.ConvertFromPixel(Owner.Width, false);
            numUnitV.Value = (decimal)converter.ConvertFromPixel(Owner.Height, true);
            // Re-register event handlers
            numUnitH.ValueChanged += numUnitH_ValueChanged;
            numUnitV.ValueChanged += numUnitV_ValueChanged;
        }

        private void applyDpiScalingMode()
        {
            applyDpiFromSettings();
            applyUnitFromSettings();
            switch (DpiScalingMode)
            {
                case DpiScalingMode.Manual:
                    panDpiH.Enabled = true;
                    panDpiV.Enabled = false;
                    break;
                case DpiScalingMode.ManualBidirectional:
                    panDpiH.Enabled = true;
                    panDpiV.Enabled = true;
                    break;
                default:
                    panDpiH.Enabled = false;
                    panDpiV.Enabled = false;
                    break;
            }
        }

        private void comDpiScalingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DpiScalingMode = (DpiScalingMode)comDpiScalingMode.SelectedIndex;
            invokeCalibrationChanged();
            applyDpiScalingMode();
        }

        private void numDpiH_ValueChanged(object sender, EventArgs e)
        {
            MonitorDpi = (float)Math.Round(numDpiH.Value, 2);
            if (DpiScalingMode == DpiScalingMode.Manual)
                VerticalMonitorDpi = MonitorDpi;
            invokeCalibrationChanged();
            applyUnitFromSettings();
        }

        private void numDpiV_ValueChanged(object sender, EventArgs e)
        {
            VerticalMonitorDpi = (float)Math.Round(numDpiV.Value, 2);
            invokeCalibrationChanged();
            applyUnitFromSettings();
        }

        private void comUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comUnits.SelectedValue != null)
            {
                MeasuringUnit = (MeasuringUnit)comUnits.SelectedValue;
                applyUnitFromSettings();
            }
        }

        private void invokeClose()
        {
            this.Owner.Move -= Owner_Move;
            this.Owner.Resize -= Owner_Resize;
            ((BaseForm)this.Owner).ResizeModeChanged -= Owner_ResizeModeChanged;
            this.Close();
        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            invokeClose();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            setFromSettings(this.originalSettings);
            invokeCalibrationChanged();
            invokeClose();
        }

        private void numUnitH_ValueChanged(object sender, EventArgs e)
        {
            comDpiScalingMode.SelectedIndex = (int)DpiScalingMode.ManualBidirectional;
            UnitConverter converter = UnitConverter.FromSettings(Owner, currentSettings, MeasuringUnit);
            MonitorDpi = converter.ConvertToDpi((float)numUnitH.Value, Owner.Width);
            invokeCalibrationChanged();
            applyDpiFromSettings();
        }

        private void numUnitV_ValueChanged(object sender, EventArgs e)
        {
            comDpiScalingMode.SelectedIndex = (int)DpiScalingMode.ManualBidirectional;
            UnitConverter converter = UnitConverter.FromSettings(Owner, currentSettings, MeasuringUnit);
            VerticalMonitorDpi = converter.ConvertToDpi((float)numUnitV.Value, Owner.Height);
            invokeCalibrationChanged();
            applyDpiFromSettings();
        }

        private void lnkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://sourceforge.net/p/screenruler/discussion/howto/thread/22319514a3/");
        }
    }
}
