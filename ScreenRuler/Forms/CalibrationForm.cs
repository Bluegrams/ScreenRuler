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
        private string selectedMonitor;
        private MeasuringUnit selectedMeasuringUnit;

        public DpiScalingMode DpiScalingMode => currentSettings.DpiScalingMode;

        public float HorizontalDpi
        {
            get
            {
                if (DpiScalingMode == DpiScalingMode.ManualPerMonitor)
                    return currentSettings.MonitorDpiConfigurations[selectedMonitor].HorizontalDpi;
                else if (DpiScalingMode == DpiScalingMode.Manual)
                    return currentSettings.MonitorDpi;
                else
                {
                    var dpi = UnitConverter.GetDpiFromSettings(this.Owner, currentSettings);
                    return dpi.horizontal;
                }
            }
            private set
            {
                if (DpiScalingMode == DpiScalingMode.ManualPerMonitor)
                    currentSettings.MonitorDpiConfigurations[selectedMonitor].HorizontalDpi = value;
                else if (DpiScalingMode == DpiScalingMode.Manual)
                    currentSettings.MonitorDpi = value;
                else throw new ArgumentException();
            }
        }

        public float VerticalDpi
        {
            get
            {
                if (DpiScalingMode == DpiScalingMode.ManualPerMonitor)
                    return currentSettings.MonitorDpiConfigurations[selectedMonitor].VerticalDpi;
                else if (DpiScalingMode == DpiScalingMode.Manual)
                    return currentSettings.VerticalMonitorDpi;
                else
                {
                    var dpi = UnitConverter.GetDpiFromSettings(this.Owner, currentSettings);
                    return dpi.vertical ?? dpi.horizontal;
                }
            }
            private set
            {
                if (DpiScalingMode == DpiScalingMode.ManualPerMonitor)
                    currentSettings.MonitorDpiConfigurations[selectedMonitor].VerticalDpi = value;
                else if (DpiScalingMode == DpiScalingMode.Manual)
                    currentSettings.VerticalMonitorDpi = value;
                else throw new ArgumentException();
            }
        }

        public event EventHandler CalibrationChanged;

        public CalibrationForm(Settings settings)
        {
            InitializeComponent();
            this.currentSettings = settings;
            this.originalSettings = settings.Clone();
        }

        private void CalibrationForm_Load(object sender, EventArgs e)
        {
            // ------ Set scaling settings ------
            // --- Display scaling mode combo box ---
            foreach (Enum item in Enum.GetValues(typeof(DpiScalingMode)))
            {
                comDpiScalingMode.Items.Add(item.GetDescription());
            }
            // Make sure to add event handler after setting initial value here
            comDpiScalingMode.SelectedIndex = (int)DpiScalingMode;
            comDpiScalingMode.SelectedIndexChanged += comDpiScalingMode_SelectedIndexChanged;
            // --- Monitor combo box ---
            comMonitors.DataSource = MonitorSetup.Instance.Displays.Select(d => new { Text = d.FriendlyName, Value = d.DevicePath }).ToList();
            comMonitors.SelectedIndex = 0;
            applyDpiScalingMode();
            // --- Measuring unit combo box ---
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
            // ------ Owner events & settings ------
            this.Owner.Move += Owner_Move;
            this.Owner.Resize += Owner_Resize;
            ((BaseForm)this.Owner).ResizeModeChanged += Owner_ResizeModeChanged;
            setResizeMode(((BaseForm)this.Owner).ResizeMode);
        }

        private void Owner_Move(object sender, EventArgs e)
        {
            if (DpiScalingMode != DpiScalingMode.Unaware)
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
            currentSettings.InvokeChanged();
            CalibrationChanged?.Invoke(this, EventArgs.Empty);
        }

        private void applyDpiFromSettings()
        {
            // Temporarily unregister event handlers of controls to avoid loop.
            numDpiH.ValueChanged -= numDpiH_ValueChanged;
            numDpiV.ValueChanged -= numDpiV_ValueChanged;
            numDpiH.Value = (decimal)HorizontalDpi;
            numDpiV.Value = (decimal)VerticalDpi;
            // Re-register event handlers
            numDpiH.ValueChanged += numDpiH_ValueChanged;
            numDpiV.ValueChanged += numDpiV_ValueChanged;
            // Enable/ Disable vertical scaling controls
            chkBidirectional.Checked = Math.Round(HorizontalDpi, 2) != Math.Round(VerticalDpi, 2);
            numDpiV.Enabled = chkBidirectional.Checked;
        }

        private void applyUnitFromSettings()
        {
            // Temporarily unregister event handlers of controls to avoid loop.
            numUnitH.ValueChanged -= numUnitH_ValueChanged;
            numUnitV.ValueChanged -= numUnitV_ValueChanged;
            UnitConverter converter = UnitConverter.FromSettings(Owner, currentSettings, selectedMeasuringUnit);
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
                    panMonitor.Enabled = false;
                    tabPageDPI.Enabled = true;
                    tabPageSize.Enabled = true;
                    break;
                case DpiScalingMode.ManualPerMonitor:
                    panMonitor.Enabled = true;
                    tabPageDPI.Enabled = true;
                    tabPageSize.Enabled = true;
                    break;
                default:
                    panMonitor.Enabled = false;
                    tabPageDPI.Enabled = false;
                    tabPageSize.Enabled = false;
                    break;
            }
        }

        private void comDpiScalingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSettings.DpiScalingMode = (DpiScalingMode)comDpiScalingMode.SelectedIndex;
            invokeCalibrationChanged();
            applyDpiScalingMode();
        }

        private void comMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedMonitor = (string)comMonitors.SelectedValue;
            // Add new monitor if not in list.
            if (!currentSettings.MonitorDpiConfigurations.ContainsKey(selectedMonitor))
            {
                currentSettings.MonitorDpiConfigurations.Add(new MonitorDpiConfiguration(selectedMonitor));
            }
            invokeCalibrationChanged();
            applyDpiScalingMode();
        }

        private void numDpiH_ValueChanged(object sender, EventArgs e)
        {
            HorizontalDpi = (float)Math.Round(numDpiH.Value, 2);
            if (!chkBidirectional.Checked)
            {
                VerticalDpi = HorizontalDpi;
                // Temporarily unregister event handlers of controls to avoid loop.
                numDpiV.ValueChanged -= numDpiV_ValueChanged;
                numDpiV.Value = (decimal)HorizontalDpi;
                // Re-register event handlers
                numDpiV.ValueChanged += numDpiV_ValueChanged;
            }
            invokeCalibrationChanged();
            applyUnitFromSettings();
        }

        private void numDpiV_ValueChanged(object sender, EventArgs e)
        {
            VerticalDpi = (float)Math.Round(numDpiV.Value, 2);
            invokeCalibrationChanged();
            applyUnitFromSettings();
        }

        private void chkBidirectional_CheckedChanged(object sender, EventArgs e)
        {
            numDpiV.Enabled = chkBidirectional.Checked;
            if (!chkBidirectional.Checked)
                numDpiV.Value = numDpiH.Value;
        }

        private void comUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comUnits.SelectedValue != null)
            {
                selectedMeasuringUnit = (MeasuringUnit)comUnits.SelectedValue;
                applyUnitFromSettings();
            }
        }

        private void numUnitH_ValueChanged(object sender, EventArgs e)
        {
            UnitConverter converter = UnitConverter.FromSettings(Owner, currentSettings, selectedMeasuringUnit);
            HorizontalDpi = converter.ConvertToDpi((float)numUnitH.Value, Owner.Width);
            invokeCalibrationChanged();
            applyDpiFromSettings();
        }

        private void numUnitV_ValueChanged(object sender, EventArgs e)
        {
            UnitConverter converter = UnitConverter.FromSettings(Owner, currentSettings, selectedMeasuringUnit);
            VerticalDpi = converter.ConvertToDpi((float)numUnitV.Value, Owner.Height);
            invokeCalibrationChanged();
            applyDpiFromSettings();
        }

        private void lnkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://sourceforge.net/p/screenruler/discussion/howto/thread/22319514a3/");
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
            this.currentSettings = this.originalSettings;
            invokeCalibrationChanged();
            invokeClose();
        }
    }
}
