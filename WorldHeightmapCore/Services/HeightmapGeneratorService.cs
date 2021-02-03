using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using WorldHeightmapCore.Http;
using WorldHeightmapCore.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Runtime.InteropServices;
using WorldHeightmapCore.Extensions;

namespace WorldHeightmapCore.Services
{
    public class HeightmapGeneratorService
    {
        private readonly ElevationClient _elevation;
        private readonly EarthClient _earth;
        private const int BreakSquishAfter = 100;
        public const double HeightResize = 100; //32768.0; //512 * 40;

        public HeightmapGeneratorService(ElevationClient elevation, EarthClient earth)
        {
            _elevation = elevation;
            _earth = earth;
        }

        /// <summary>
        /// Generate a heightmap from a GeneratorRequest
        /// </summary>
        /// <param name="request">A request to make the heightmap based off of.</param>
        /// <param name="apiKey">The Google Elevation API key</param>
        /// <returns>A MemoryStream of the raw heightmap file</returns>
        public async Task<GeneratorResult?> GenerateHeightmap(GeneratorRequest request)
        {
            double[,] elevationPoints;
            if (request.ElevationData)
            {
                var tmp = await ReadElevationDatasetAsync(request.DataFileLocation, request.Width, request.Height);

                if (tmp is null)
                    return null;

                elevationPoints = tmp;
            }
            else
            {
                _elevation.Initialize(request.ApiKey);

                var globalPoints = GetElevationPoints(request);

                var roundedPoints = globalPoints.Round(5);

                elevationPoints = await _elevation.GetElevationData(roundedPoints);
            }

            var heightmapPoints = ConvertElevationToHeightmapValues(elevationPoints, request, out var waterHeight);

            var water = GetWaterHeights(heightmapPoints, waterHeight);

            var rotatedPoints = RotatePoints(heightmapPoints);

            var heightmap = GetHeightmapByteArray(rotatedPoints, request);

            return new()
            {
                WaterHeight = water.Item1,
                DepthHeight = water.Item2,
                AbyssHeight = water.Item3,
                Heightmap = heightmap.Item1,
                HeightmapBitmap = heightmap.Item2,
                RawElevationData = elevationPoints,
                ModifedElevationData = rotatedPoints
            };
        }

        private double[,] RotatePoints(double[,] data)
        {
            var xw = data.GetLength(0);
            var yw = data.GetLength(1);
            var output = new double[xw, yw];

            int xout = 0;
            int yout = yw - 1;

            for (int x = 0; x < xw; x++)
            {
                for (int y = 0; y < yw; y++)
                {
                    output[xout, yout--] = data[x, y];
                }

                xout++;
                yout = yw - 1;
            }

            return output;
        }

        private (byte[], Bitmap) GetHeightmapByteArray(double[,] data, GeneratorRequest request)
        {
            //var stride = request.Width * 2;

            //var end = stride % 4;

            //while(end != 0)
            //{
            //    stride += 4 / end;
            //    end = stride % 4;
            //}
            
            byte[] bytes = new byte[data.Length * 2];
            using MemoryStream ms = new(bytes);
            using BinaryWriter writer = new(ms);
            //var map = new Bitmap(request.Width, request.Height, PixelFormat.Format16bppRgb565);

            //var bitdata = map.LockBits(new(0, 0, request.Width, request.Height), ImageLockMode.ReadWrite, PixelFormat.Format16bppRgb565);

            for (int y = 0; y < data.GetLength(1); y++)
            {
                for (int x = 0; x < data.GetLength(0); x++)
                {
                    var point = data[x, y];

                    var large = point * HeightResize;

                    ushort value;
                    if (large < ushort.MaxValue && large > ushort.MinValue)
                        value = Convert.ToUInt16(large);
                    else if (large > ushort.MinValue)
                        value = ushort.MaxValue;
                    else
                        value = ushort.MinValue;

                    writer.Write(BitConverter.GetBytes(value));
                }
            }

            Bitmap bmp = new(request.Width, request.Height, PixelFormat.Format16bppRgb565);
            // Lock the bits
            Rectangle bounds = new(0, 0, request.Width, request.Height);
            BitmapData bmpData = bmp.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format16bppRgb565);
            IntPtr ptrToFirstPixel = bmpData.Scan0;

            byte[] buffer = new byte[request.Height * bmpData.Stride];

            for (int y = 0; y < request.Height; y++)
            {
                Buffer.BlockCopy(bytes, y * request.Width * 2, buffer, y * bmpData.Stride, request.Width * 2);
            }

            Marshal.Copy(buffer, 0, ptrToFirstPixel, buffer.Length);
            bmp.UnlockBits(bmpData);

            return (bytes, bmp);
        }

        private (double, double, double) GetWaterHeights(double[,] sqished, double waterHeight)
        {
            double depthHeight = 0.0;
            double abyssHeight = 0.0;

            if(waterHeight != 0.0)
            {
                var waterPoints = GetAllPointsBelow(sqished, waterHeight);

                waterPoints.Sort();

                var thirtythird = .33 * waterPoints.Count;

                var rtt = (int)Math.Round(thirtythird);

                abyssHeight = waterPoints[rtt];

                var sixtysix = .66 * waterPoints.Count;

                var rss = (int)Math.Round(sixtysix);

                depthHeight = waterPoints[rss];
            }

            return (waterHeight, depthHeight, abyssHeight);
        }

        private List<double> GetAllPointsBelow(double[,] data, double cap)
        {
            List<double> output = new List<double>();
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    if (data[x, y] <= cap)
                        output.Add(data[x, y]);
                }
            }

            return output;
        }

        private double[,] ConvertElevationToHeightmapValues(double[,] elevation, GeneratorRequest request, out double waterHeight)
        {
            // Get the average distance from zero ...
            var average = GetAverageDistFromZero(elevation);
            // ... Shift the dataset by the inverse of that ...
            var shiftedSet = ShiftPoints(elevation, 0 - average);
            // ... Squish the set so its min and max are close to a difference of 50 ...
            var squishedSet = SquishPoints(shiftedSet, request.SquishPercent);
            // ... get the new min and max ...
            var minmax = GetMinMax(squishedSet);

            double[,] zeroedSet;
            switch(request.WaterOption)
            {
                case WaterType.Automatic:
                    // ... and zero the data set by shifting it by the inverse of the min ...
                    zeroedSet = ShiftPoints(squishedSet, -minmax.Item1);

                    waterHeight = Math.Abs(minmax.Item1);
                    break;
                case WaterType.Flatten:
                    zeroedSet = DropNegatives(squishedSet);
                    waterHeight = 0.0;
                    break;
                default:
                    throw new ArgumentNullException(nameof(request.WaterOption), "Water Option can't be null");
            }

            return zeroedSet;
        }

        private double[,] DropNegatives(double[,] squished)
        {
            var xw = squished.GetLength(0);
            var yw = squished.GetLength(1);
            var data = new double[xw, yw];

            for (int x = 0; x < xw; x++)
            {
                for (int y = 0; y < yw; y++)
                {
                    if (squished[x, y] <= 0)
                        data[x, y] = 0.0;
                    else 
                        data[x, y] = squished[x, y];
                }
            }

            return data;
        }

        private double[,] SquishPoints(double[,] shifted, int squish)
        {
            var xw = shifted.GetLength(0);
            var yw = shifted.GetLength(1);
            var data = new double[xw, yw];
            Array.Copy(shifted, data, shifted.Length);

            float squishPercentage = squish / 100f;

            int emergencybreak = 0;
            var below = GetBelowThreshold(data);
            while (below < squishPercentage
                && emergencybreak++ < BreakSquishAfter)
            {
                var multipler = (1 - below) / 2;

                for (int x = 0; x < data.GetLength(0); x++)
                {
                    for (int y = 0; y < data.GetLength(1); y++)
                    {
                        data[x, y] *= multipler;
                    }
                }

                below = GetBelowThreshold(data);
            }

            return data;
        }

        private (double, double) GetBelowAboveAverages(double[,] data)
        {
            var counts = GetAboveBelowZeroCounts(data);

            double below = (double)counts.Item2 / data.Length;
            double above = (double)counts.Item1 / data.Length;

            return (below, above);
        }

        private double GetBelowThreshold(double[,] data)
        {
            var goals = GetThresholdGoals(data);

            double reachedgoal = 0.0;
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    var point = data[x, y];

                    if (point > goals.Item1 && point < goals.Item2)
                        reachedgoal++;
                }
            }

            double reachedgoalpercent = reachedgoal / data.Length;

            return reachedgoalpercent;
        }

        private (double, double) GetThresholdGoals(double[,] data)
        {
            var counts = GetAboveBelowZeroCounts(data);

            double belowZeroPercentage = (double)counts.Item1 / data.Length;

            double mingoal = -(50 * belowZeroPercentage);
            double maxgoal = 50 * (1 - belowZeroPercentage);

            return (mingoal, maxgoal);
        }

        private (double, double) GetMinMax(double[,] set)
        {
            double max = set[0, 0];
            double min = set[0, 0];

            for (int x = 0; x < set.GetLength(0); x++)
            {
                for (int y = 0; y < set.GetLength(1); y++)
                {
                    if (min > set[x, y])
                        min = set[x, y];

                    if (max < set[x, y])
                        max = set[x, y];
                }
            }

            return (min, max);
        }

        private (int, int) GetAboveBelowZeroCounts(double[,] set)
        {
            int above = 0;
            int below = 0;

            for (int x = 0; x < set.GetLength(0); x++)
            {
                for (int y = 0; y < set.GetLength(1); y++)
                {
                    if (set[x, y] > 0)
                        above++;
                    else if (set[x, y] < 0)
                        below++;
                }
            }

            return (below, above);
        }

        private double[,] ShiftPoints(double[,] elevation, double shift)
        {
            var xw = elevation.GetLength(0);
            var yw = elevation.GetLength(1);
            var data = new double[xw, yw];

            for (int x = 0; x < xw; x++)
            {
                for (int y = 0; y < yw; y++)
                {
                    data[x, y] = elevation[x, y] + shift;
                }
            }

            return data;
        }

        private double GetAverageDistFromZero(double[,] elevation)
        {
            int c = 0;
            int splits = 0;
            double total = 0.0;
            double average = 0.0;
            

            for(int x = 0; x < elevation.GetLength(0); x++)
            {
                for (int y = 0; y < elevation.GetLength(1); y++)
                {
                    if(total > double.MaxValue - elevation[x, y])
                    {
                        var tmp = total / c;
                        average = (tmp + average) / 2;
                        c = 0;
                        total = 0.0;
                        splits++;
                    }
                        
                    total += Math.Abs(0 - elevation[x, y]);
                    c++;
                }
            }

            var last = total / c;
            if (splits > 0)
                average = (last + average) / 2;
            else
                average = last;

            return average;
        }

        private async Task<double[,]?> ReadElevationDatasetAsync(string file, int width, int height)
        {
            using FileStream fs = new(file, FileMode.Open);
            using StreamReader sr = new(fs);

            // we dont want the first line.
             _ = await sr.ReadLineAsync();
            // the data is on the second line.
            var data = await sr.ReadLineAsync();

            if (data is null)
            {
                // TODO: Log no data
                return null;
            }

            var parts = data.Split(",");

            double[,] output = new double[width, height];

            int i = 0;
            for(int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (double.TryParse(parts[i++], out var num))
                        output[x, y] = num;
                    else
                    {
                        // TODO: Log invalid file format.
                        return null;
                    }
                }
            }

            return output;
        }

        private GlobalPosition[,] GetElevationPoints(GeneratorRequest request)
        {
            var initial = new GlobalPosition()
            {
                Latitude = request.Latitude,
                Longitude = request.Longitude
            };

            var bounds = GetBounds(initial, request.KilometerWidth, request.KilometerHeight);

            var points = BuildPointsList(request, initial, bounds);

            return points;
        }

        private GlobalPosition[,] BuildPointsList(GeneratorRequest request, GlobalPosition initial, GlobalPosition[] bounds)
        {
            // counts down the width, then over one col, etc....

            double width = bounds[0].Longitude - bounds[1].Longitude;
            double height = bounds[0].Latitude - bounds[1].Latitude;

            GlobalPosition[,] points = new GlobalPosition[request.Width, request.Height];

            var offsets = BuildOffsetTree(initial, width, height, request);

            for (int x = 0; x < request.Width; x++)
                for (int y = 0; y < request.Height; y++)
                    points[x, y] = initial + offsets[x, y];

            return points;
        }

        private GlobalPosition[,] BuildOffsetTree(GlobalPosition initial, double width, double height, GeneratorRequest request)
        {
            var xSplit = width / request.Width;
            var ySplit = height / request.Height;

            var halfHeight = request.Height / 2;
            var halfWidth = request.Width / 2;

            GlobalPosition[,] tree = new GlobalPosition[request.Width, request.Height];

            int xc = 0;
            for(int x = -halfWidth; x <= halfWidth; x++)
            {
                int yc = 0;
                for(int y = -halfHeight; y <= halfHeight; y++)
                {
                    tree[xc, yc++] = new()
                    {
                        Latitude = y * ySplit,
                        Longitude = x * xSplit
                    };
                }
                xc++;
            }

            return tree;
        }

        private GlobalPosition[] GetBounds(GlobalPosition initial, int realWidth, int realHeight)
        {
            GlobalPosition[] bounds = new GlobalPosition[2];

            var top = initial.Displace(0, realHeight / 2);
            GlobalPosition left;
            if (realWidth == realHeight)
                left = new()
                {
                    Latitude = initial.Latitude,
                    Longitude = initial.Longitude + (top.Latitude - initial.Latitude)
                };
            else
                left = initial.Displace(270, realWidth / 2);

            var start = new GlobalPosition()
            { 
                Latitude = top.Latitude,
                Longitude = left.Longitude
            };

            bounds[0] = start;

            var diff = start - initial;

            var end = new GlobalPosition()
            {
                Latitude = initial.Latitude - diff.Latitude,
                Longitude = initial.Longitude - diff.Longitude
            };

            bounds[1] = end;

            return bounds;
        }
    }
}
