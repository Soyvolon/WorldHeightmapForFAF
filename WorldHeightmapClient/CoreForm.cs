﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using WorldHeightmapClient.Properties;

using WorldHeightmapCore.Data;
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

        public readonly string USER_FILES = "";
        public const string APP_FILES = "Data";

        private List<ElevationDataFile> ElevationDataFiles { get; init; }

        public CoreForm(IServiceProvider services, HeightmapGeneratorService heightmap)
        {
            USER_FILES = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "World Heightmap Generator");

            _services = services;
            _heightmap = heightmap;

            InitializeComponent();

            mapHeight.SelectedIndex = 3;
            mapWidth.SelectedIndex = 3;

            var source = new ElevationDataFile();
            ElevationDataFiles = LoadElevationData();
            savedElevationBox.DataSource = ElevationDataFiles;
            savedElevationBox.DisplayMember = nameof(source.Display);
            savedElevationBox.SelectedIndex = -1;
        }

        private List<ElevationDataFile> LoadElevationData()
        {
            if (!Directory.Exists(USER_FILES))
                Directory.CreateDirectory(USER_FILES);

            List<ElevationDataFile> files = new();

            var appfiles = Directory.GetFiles(APP_FILES, "*.whcd");
            var userfiles = Directory.GetFiles(USER_FILES, "*.whcd");

            List<string> filePaths = new();
            filePaths.AddRange(appfiles);
            filePaths.AddRange(userfiles);

            foreach (var f in filePaths)
            {
                try
                {
                    using FileStream fs = new(f, FileMode.Open);
                    using StreamReader sr = new(fs);

                    var first = sr.ReadLine();
                    var data = first.Split(",");
                    // we assume the file is saved correctly.
                    files.Add(new()
                    {
                        Display = data[0],
                        Width = int.Parse(data[1]),
                        Height = int.Parse(data[2]),
                        Path = f
                    });
                }
                catch
                {
                    // TODO log failed file load to output.
                    continue;
                }
            }

            return files;
        }

        private async void GenerateButton_ClickAsync(object sender, System.EventArgs e)
        {
            var builder = new GeneratorRequestBuilder();
            if (dataTab.SelectedIndex == 0)
            {
                if (string.IsNullOrWhiteSpace(Settings.Default.ApiKey))
                {
                    if (!SaveNewElevationApiKey())
                    {
                        MessageBox.Show("No API Key was found. Please save a valid API key.", "No API Key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (!GlobalPosition.TryParseDegrees(latitudeIn.Text, out var lat))
                {
                    MessageBox.Show("Invalid Latitude. Value must be in one of the following formats:\nDegrees\n" +
                        "Degrees-Minutes-Seconds-Hemesphere - Ex: 36°30'55.42\"W", "Invalid Latitude", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!GlobalPosition.TryParseDegrees(longitudeIn.Text, out var lng))
                {
                    MessageBox.Show("Invalid Longitude. Value must be in one of the following formats:\nDegrees\n" +
                        "Degrees-Minutes-Seconds-Hemesphere - Ex: 36°30'55.42\"W", "Invalid Longitude", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (mapWidth.SelectedItem is null)
                {
                    MessageBox.Show("No map width selected.", "Invalid Map Width", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!heightSame.Checked && mapHeight.SelectedItem is null)
                {
                    MessageBox.Show("No map height selected and height same is not checked.", "Invalid Map Height", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                builder.WithLatitude(lat)
                    .WithLongitude(lng)
                    .WithWidth(GetSizeValue(mapWidth.SelectedIndex))
                    .WithKilometerWidth(GetKmValue(mapWidth.SelectedIndex))
                    .WithHeight(heightSame.Checked ? builder.Width : GetSizeValue(mapHeight.SelectedIndex))
                    .WithKilometerHeight(heightSame.Checked ? builder.KilometerWidth : GetKmValue(mapHeight.SelectedIndex))
                    .WithApiKey(Settings.Default.ApiKey);
            }
            else
            {
                if (savedElevationBox.SelectedItem is not ElevationDataFile file)
                {
                    MessageBox.Show("No saved elevation dataset selected.", "Invalid Elevation Dataset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                builder.WithElevationDataset(file.Path)
                    .WithWidth(file.Width)
                    .WithHeight(file.Height);
            }

            using var lockout = new ToolsLockout(this);

            if (automaticWater.Checked)
                builder.WithAutomaticWater();
            else if (flattenWater.Checked)
                builder.WithFlattenWater();

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

            var result = await _heightmap.GenerateHeightmap(builder.Build());

            // TODO: hold data for later.
            await File.WriteAllBytesAsync(@"Data\testoutput.raw", result.Heightmap);
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

        public static int GetKmValue(int index)
            => index switch
            {
                0 => (int)1.25e3, 
                1 => (int)2.5e3, 
                2 => (int)5e3, 
                3 => (int)10e3, 
                4 => (int)20e3,
                5 => (int)40e3,
                6 => (int)80e3,
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

        private void HeightSame_CheckedChanged(object sender, EventArgs e)
        {
            if (heightSame.Checked)
            {
                mapHeight.Enabled = false;
                MapWidth_SelectedIndexChanged(sender, e);
            }
            else mapHeight.Enabled = true;
        }

        private void MapWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (heightSame.Checked)
                mapHeight.SelectedIndex = mapWidth.SelectedIndex;
        }
    }
}
