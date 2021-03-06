﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Extensions.DependencyInjection;

using WorldHeightmap.Client.Popups;
using WorldHeightmap.Client.Properties;

using WorldHeightmap.Core.Data;
using WorldHeightmap.Core.Models;
using WorldHeightmap.Core.Services;

namespace WorldHeightmap.Client
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
                _form.resultSection.Panel2.Enabled = false;
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {

                    }

                    _form.settingsBox.Enabled = true;
                    _form.resultSection.Panel2.Enabled = true;
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
        private readonly GeneratorResultCacheService _cahce;

        public readonly string USER_FILES = "";
        public const string APP_FILES = "Data";

        private BindingList<ElevationDataFile> ElevationDataFiles { get; init; }

        public CoreForm(IServiceProvider services, HeightmapGeneratorService heightmap, GeneratorResultCacheService cache)
        {
            USER_FILES = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "World Heightmap Generator");

            _services = services;
            _heightmap = heightmap;
            _cahce = cache;

            InitializeComponent();

            mapHeight.SelectedIndex = 3;
            mapWidth.SelectedIndex = 3;

            ElevationDataFiles = new(LoadElevationData());
            savedElevationBox.DataSource = ElevationDataFiles;
            ElevationDataFile source;
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
                    // we assume the file is saved correctly.
                    files.Add(LoadFile(first, f));
                }
                catch
                {
                    // TODO log failed file load to output.
                    continue;
                }
            }

            return files;
        }

        private ElevationDataFile LoadFile(string firstLine, string path)
        {
            var data = firstLine.Split(",");

            return new()
            {
                Display = data[0],
                Width = int.Parse(data[1]),
                Height = int.Parse(data[2]),
                Path = path
            };
        }

        public async Task<ElevationDataFile> SaveDatasetAsync(string path, string name, GeneratorResult result)
        {
            var xw = result.RawElevationData.GetLength(0);
            var yw = result.RawElevationData.GetLength(1);
            string top = $"{name}, {xw}, {yw}";

            List<string> dat = new();
            for (int x = 0; x < xw; x++)
                for (int y = 0; y < yw; y++)
                    dat.Add(result.RawElevationData[x, y].ToString());

            string[] file = new string[]
            {
                top,
                string.Join(", ", dat)
            };

            await File.WriteAllLinesAsync(path, file);

            return new()
            {
                Display = name,
                Width = xw,
                Height = yw,
                Path = path
            };
        }

        public async Task SaveGeneratorResultsAsync()
        {
            var lastResult = _cahce.GetResult();
            if(lastResult is null)
            {
                MessageBox.Show("Run the generator before saving a result!", "No Result to Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var save = _services.GetRequiredService<SaveDataForm>();
            var res = save.ShowDialog(this);

            if (res == DialogResult.Abort || save.Aborted)
                return;

            using FileStream fs = new(Path.Join(save.Folder, $"{save.HeightmapName}.raw"), FileMode.Create, FileAccess.Write);
            using BinaryWriter w = new(fs);

            w.Write(lastResult.Heightmap);

            if (save.SaveDataset)
            {
                var file = await SaveDatasetAsync(Path.Join(USER_FILES, $"{save.ElevationDatasetName}.whcd"), save.ElevationDatasetName, lastResult);
                ElevationDataFiles.Add(file);
                savedElevationBox.Refresh();
            }

            if (save.SaveExtraData)
            {
                if(resultDisplay.Image is not null)
                    resultDisplay.Image.Save(Path.Join(save.Folder, $"{save.HeightmapName}.display_image.bmp"), ImageFormat.Bmp);

                var xw = lastResult.ModifedElevationData.GetLength(0);
                var yw = lastResult.ModifedElevationData.GetLength(1);
                List<string> dat = new();
                for (int x = 0; x < xw; x++)
                    for (int y = 0; y < yw; y++)
                        dat.Add($"({x}, {y}): {lastResult.ModifedElevationData[x, y]}");

                await File.WriteAllLinesAsync(Path.Join(save.Folder, $"{save.HeightmapName}.modified_elevation_data.txt"), dat);

                dat = new();
                for (int x = 0; x < xw; x++)
                    for (int y = 0; y < yw; y++)
                        dat.Add($"({x}, {y}): {lastResult.RawElevationData[x, y]}");

                await File.WriteAllLinesAsync(Path.Join(save.Folder, $"{save.HeightmapName}.raw_elevation_data.txt"), dat);
            }
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

                builder.WithApiKey(Settings.Default.ApiKey)
                    .WithLatitude(lat)
                    .WithLongitude(lng)
                    .WithWidth(GetSizeValue(mapWidth.SelectedIndex))
                    .WithKilometerWidth(GetKmValue(mapWidth.SelectedIndex))
                    .WithHeight(heightSame.Checked ? builder.Width : GetSizeValue(mapHeight.SelectedIndex))
                    .WithKilometerHeight(heightSame.Checked ? builder.KilometerWidth : GetKmValue(mapHeight.SelectedIndex));
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
                builder.WithRoundSmoothing((float)roundToNearest.Value);
            else if (normalSmoothing.Checked)
            {
                try
                {
                    builder.WithNormalSmoothing((int)averagePasses.Value, (int)fwhmCounter.Value, (int)kernelSize.Value);
                }
                catch (ArgumentException ae)
                {
                    MessageBox.Show(ae.Message, "Invalid Kernel Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            builder.WithSquishPercent((int)squishPercent.Value);

            var request = builder.Build();
            var result = await _heightmap.GenerateHeightmap(request);

            waterElevation.Value = result.WaterHeight < 0 ? 0 : (decimal)result.WaterHeight;
            depthElevation.Value = result.DepthHeight< 0 ? 0 : (decimal)result.DepthHeight;
            abyssElevation.Value = result.AbyssHeight < 0 ? 0 : (decimal)result.AbyssHeight;

            _ = Task.Run(async () => await DisplayImage(result.Heightmap, request));
            _ = Task.Run(async () => await SaveDatasetAsync(Path.Join(USER_FILES, "Temp.whcd"), "[TEMP] Last Dataset Run", result));

            _cahce.SetResult(result);
        }

        public Task DisplayImage(byte[] bytes, GeneratorRequest request)
        {
            Bitmap bmp = new Bitmap(request.Width, request.Height, PixelFormat.Format16bppRgb565);
            // Lock the bits
            Rectangle bounds = new Rectangle(0, 0, request.Width, request.Height);
            BitmapData bmpData = bmp.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format16bppRgb565);
            IntPtr ptrToFirstPixel = bmpData.Scan0;

            byte[] buffer = new byte[request.Height * bmpData.Stride];

            for (int y = 0; y < request.Height; y++)
            {
                Buffer.BlockCopy(bytes, y * request.Width * 2, buffer, y * bmpData.Stride, request.Width * 2);
            }

            Marshal.Copy(buffer, 0, ptrToFirstPixel, buffer.Length);
            bmp.UnlockBits(bmpData);

            resultDisplay.Image = bmp;
            //resultDisplay.Refresh();

            return Task.CompletedTask;
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

        private async void SaveButton_Click(object sender, EventArgs e)
            //=> _ = Task.Run(async () => await SaveGeneratorResultsAsync());
            => await SaveGeneratorResultsAsync();
    }
}
