﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScreenRuler.Colors;
using ScreenRuler.Units;

namespace ScreenRuler
{
    public partial class SettingsForm : Form
    {
        Settings settings;

        public SettingsForm(Settings settings)
        {
            this.settings = settings;
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // --- Load: First Page ---
            txtDPI.Text = settings.MonitorDpi.ToString();
            foreach (Enum item in Enum.GetValues(typeof(MeasuringUnit)))
            {
                comUnits.Items.Add(item.GetDescription());
            }
            comUnits.SelectedIndex = (int)settings.MeasuringUnit;
            RadioButton selected = grpColors.Controls
                .OfType<RadioButton>()
                .Where(b => b.Tag.ToString() == settings.SelectedTheme.ToString())
                .First();
            selected.Checked = true;
            // --- Load: Second Page ---
            numMediumStep.Value = settings.MediumStep;
            numLargeStep.Value = settings.LargeStep;
            numMarkerThickness.Value = settings.MarkerThickness;
            chkMarkerSymbol.Checked = settings.ShowMarkerSymbol;
            chkToolTip.Checked = settings.ShowToolTip;
        }

        private void radTheme_CheckedChanged(object sender, EventArgs e)
        {
            if (!((RadioButton)sender).Checked) return;
            // Enable color chooser dependent on custom colors radio button
            panCustomColors.Enabled = radCustom.Checked;
            // Load the colors of the current theme
            Theme theme = null;
            if (radLight.Checked) theme = CommonThemes.LightTheme;
            else if (radDark.Checked) theme = CommonThemes.DarkTheme;
            // only set to currently used theme if its custom
            else if (settings.SelectedTheme == ThemeOption.Custom) theme = settings.Theme;
            if (theme != null)
            {
                butColorBackground.BackColor = theme.Background;
                butColorTicks.BackColor = theme.TickColor;
                butColorDivideMarkers.BackColor = theme.CenterLineColor;
                butColorMouseMarker.BackColor = theme.MouseLineColor;
                butColorCustomMarkers.BackColor = theme.CustomLinesColor;
            }
        }

        private void butColorChooser_Click(object sender, EventArgs e)
        {
            ColorDialog colDialog = new ColorDialog();
            colDialog.Color = ((Button)sender).BackColor;
            colDialog.CustomColors = new int[] { ColorTranslator.ToOle(colDialog.Color) };
            if (colDialog.ShowDialog() == DialogResult.OK)
            {
                ((Button)sender).BackColor = colDialog.Color;
            }
        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            // --- Apply: First Page ---
            if (int.TryParse(txtDPI.Text, out int result))
            {
                // Set monitor DPI
                settings.MonitorDpi = result;
                // Set measuring unit
                var unit = (MeasuringUnit)comUnits.SelectedIndex;
                settings.MeasuringUnit = unit;
                // Set color theme
                var themeVal = grpColors.Controls.OfType<RadioButton>().Where(b => b.Checked).First().Tag;
                settings.SelectedTheme = (ThemeOption)Enum.Parse(typeof(ThemeOption), themeVal.ToString());
                if (settings.SelectedTheme == ThemeOption.Custom)
                    setCustomThemeColors(settings.Theme);
            }
            else
            {
                MessageBox.Show(Properties.Resources.SettingsInvalidDpi);
                this.DialogResult = DialogResult.None;
                return;
            }
            // --- Apply: Second Page ---
            settings.MediumStep = (int)numMediumStep.Value;
            settings.LargeStep = (int)numLargeStep.Value;
            settings.MarkerThickness = (byte)numMarkerThickness.Value;
            settings.ShowMarkerSymbol = chkMarkerSymbol.Checked;
            settings.ShowToolTip = chkToolTip.Checked;
            this.DialogResult = DialogResult.OK;
        }

        // Reads all color values from color chooser buttons
        private void setCustomThemeColors(Theme theme)
        {
            theme.Background = butColorBackground.BackColor;
            theme.TickColor = butColorTicks.BackColor;
            theme.LengthLabelColor = butColorTicks.BackColor;
            theme.CenterLineColor = butColorDivideMarkers.BackColor;
            theme.ThirdsLinesColor = butColorDivideMarkers.BackColor;
            theme.MouseLineColor = butColorMouseMarker.BackColor;
            theme.CustomLinesColor = butColorCustomMarkers.BackColor;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
