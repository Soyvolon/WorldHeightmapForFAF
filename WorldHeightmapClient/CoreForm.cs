using System;
using System.Windows.Forms;

using WorldHeightmapClient.Properties;

using WorldHeightmapCore.Models;
using WorldHeightmapCore.Services;

namespace WorldHeightmapClient
{
    public partial class CoreForm : Form
    {
        public class ToolsLockout : IDisposable
        {
            private bool disposedValue;
            private readonly CoreForm _form;

            public ToolsLockout(CoreForm form)
            {
                this._form = form;
                _form.settingsBox.Enabled = false;
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {

                    }

                    _form.settingsBox.Enabled = true;
                    disposedValue = true;
                }
            }

            void IDisposable.Dispose()
            {
                // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }

        private readonly IServiceProvider _services;
        private readonly HeightmapGeneratorService _heightmap;

        public CoreForm(IServiceProvider services, HeightmapGeneratorService heightmap)
        {
            _services = services;
            _heightmap = heightmap;

            InitializeComponent();
        }

        private async void GenerateButton_ClickAsync(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Settings.Default.ApiKey))
            {
                if (!SaveNewElevationApiKey())
                {
                    MessageBox.Show("No API Key was found. Please save a valid API key.", "No API Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if(!double.TryParse(latitudeIn.Text, out var lat))
            {
                MessageBox.Show("Invalid Latitude. Value must be in one of the following formats:\nDegrees", "Invalid Latitude", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(longitudeIn.Text, out var lng))
            {
                MessageBox.Show("Invalid Longitude. Value must be in one of the following formats:\nDegrees", "Invalid Longitude", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var lockout = new ToolsLockout(this);

            var builder = new GeneratorRequestBuilder();
            builder.WithLatitude(lat)
                .WithLongitude(lng)
                .WithWidht(GetSizeValue(mapWidth.SelectedIndex))
                .WithHeight(heightSame.Checked ? builder.Width : GetSizeValue(mapHeight.SelectedIndex));

            if (automaticWater.Checked)
                builder.WithAutomaticWater();
            else if (noWater.Checked)
                builder.WithNoWater();
            else if (manualWater.Checked)
                builder.WithManualWater((float)waterElevation.Value, (float)depthElevation.Value, (float)abyssElevation.Value);

            if (noSquash.Checked)
                builder.WithNoSquash();
            else if (flattenSquash.Checked)
                builder.WithFlattenSquash((int)flattenMin.Value, (int)flattenMax.Value);
            else if (compressSquash.Checked)
                builder.WithCompressSquash((int)compressPasses.Value);

            if (noSmoothing.Checked)
                builder.WithNoSmoothing();
            else if (roundSmoothing.Checked)
                builder.WithRoundSmoothing(GetRoundToNearest(roundToNearest.SelectedIndex));
            else if (averageSmoothing.Checked)
                builder.WithAverageSmoothing((int)averagePasses.Value, (float)maxVertexDifference.Value);

            await _heightmap.GenerateHeightmap(builder.Build());
        }

        public static int GetSizeValue(int index)
            => index switch
            {
                0 => 65, // 64 + 1
                1 => 129, // 128 + 1
                2 => 257, // 256 + 1
                3 => 513, // 512 + 1
                4 => 1025, // 1024 + 1
                5 => 2049, // 2048 + 1
                6 => 4097, // 4096 + 1
                _ => 0
            };

        public static float GetRoundToNearest(int index)
            => index switch
            {
                0 => 0.25f,
                1 => 0.5f,
                2 => 1.0f,
                _ => 0.25f
            };

    }
}
