﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using WorldHeightmap.Core.Extensions;
using WorldHeightmap.Core.Http;
using WorldHeightmap.Core.Models;

namespace WorldHeightmap.Core.Services
{
    public class HeightmapGeneratorService
    {
        private readonly ElevationClient _elevation;
        private const int BreakSquishAfter = 100;
        public const double HeightResize = 100; //32768.0; //512 * 40;

        public HeightmapGeneratorService(ElevationClient elevation)
        {
            _elevation = elevation;
        }

        /// <summary>
        /// Generate a heightmap from the details provided in the GeneratorRequest
        /// </summary>
        /// <param name="request">A request to build a heightmap from</param>
        /// <returns>A GeneratorResult that contains the generated heightmap information, or null if no map was generated</returns>
        public async Task<GeneratorResult> GenerateHeightmap(GeneratorRequest request)
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

            var heightmapPoints = ConvertElevationToHeightmapValues(elevationPoints, request);

            SquashPoints(heightmapPoints, request);

            SmoothPoints(heightmapPoints, request);

            (double, double, double) water;
            if (GetMinMax(elevationPoints).Item1 >= 0.0)
                water = (0, 0, 0);
            else
                water = GetWaterHeights(heightmapPoints, elevationPoints);

            var rotatedPoints = RotatePoints(heightmapPoints);

            var heightmap = GetHeightmapByteArray(rotatedPoints, request);

            return new GeneratorResult()
            {
                WaterHeight = water.Item1,
                DepthHeight = water.Item2,
                AbyssHeight = water.Item3,
                Heightmap = heightmap,
                RawElevationData = elevationPoints,
                ModifedElevationData = rotatedPoints
            };
        }

        private static void SmoothPoints(double[,] data, GeneratorRequest request)
        {
            switch(request.SmoothingOptions)
            {
                case Smoothing.Average:
                    for (int i = 0; i < request.AverageSmoothingPasses; i++)
                        AveragePoints(data, request.SmoothFWHM, request.KernelSize);
                    break;
                case Smoothing.Round:
                    RoundPoints(data, request.RoundSmoothingNearest);
                    break;
                case Smoothing.Combined:
                    RoundPoints(data, request.RoundSmoothingNearest);
                    for (int i = 0; i < request.AverageSmoothingPasses; i++)
                        AveragePoints(data, request.SmoothFWHM, request.KernelSize);
                    break;
            }
        }

        private static void AveragePoints(double[,] data, int fwhm, int size)
        {
            var output = new double[data.GetLength(0), data.GetLength(1)];

            var weights = GetWeights(size, FwhmToSigma(fwhm));
            var halfsize = 5 / 2;
            
            for(int x = 0; x < data.GetLength(0); x++)
            {
                for(int y = 0; y < data.GetLength(1); y++)
                {
                    double[,] tree = new double[size, size];

                    int wx = 0; int wy = 0;
                    for(int w = x - halfsize; wx < size; w++)
                    {
                        for(int h = y - halfsize; wy < size; h++)
                        {
                            if (w < 0) w = 0;
                            if (h < 0) h = 0;
                            if (w >= data.GetLength(0)) w = data.GetLength(0) - 1;
                            if (h >= data.GetLength(1)) h = data.GetLength(1) - 1;

                            tree[wx, wy++] = data[w, h];
                        }

                        wy = 0;
                        wx++;
                    }

                    var point = GetSmoothedValue(weights, tree);

                    output[x, y] = point;
                }
            }

            data.Map(output, 0, 0);
        }

        public static double FwhmToSigma(double fwhm)
        {
            return fwhm / Math.Sqrt(8 * Math.Log(2));
        }

        public static double SigmaToFwhm(double sigma)
        {
            return sigma * Math.Sqrt(8 * Math.Log(2));
        }

        public static double[,] GetWeights(int size, double fwhm)
        {
            double[,] kernels = new double[size, size];

            double sum = 0;
            int foff = (size - 1) / 2;
            double constant = 1.0 / (2 * Math.PI * Math.Pow(fwhm, 2.0));

            for (int y = -foff; y <= foff; y++)
            {
                for (int x = -foff; x <= foff; x++)
                {
                    var distance = (Math.Pow(y, 2.0) + Math.Pow(x, 2.0)) / (2 * Math.Pow(fwhm, 2.0));
                    kernels[y + foff, x + foff] = constant * Math.Exp(-distance);
                    sum += kernels[y + foff, x + foff];
                }
            }

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    kernels[y, x] = kernels[y, x] * 1d / sum;
                }
            }

            return kernels;
        }

        private static double GetSmoothedValue(double[,] weights, double[,] values)
        {
            double sum = 0.0;

            for(int x = 0; x < weights.GetLength(0); x++)
                for(int y = 0; y < weights.GetLength(1); y++)
                    sum += weights[x, y] * values[x, y];

            return sum;
        }

        private static double[,] GetDistanceFromCenter(double[,] data)
        {
            var w = data.GetLength(0);
            var h = data.GetLength(1);
            var output = new double[w, h];
            double center = data[w / 2, h / 2];
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    output[x, y] = center - data[x, y];
                }
            }

            return output;
        }

        private static double AverageDistanceFromCenter(double[,] data)
        {
            List<double> distances = new List<double>();
            var center = data[data.GetLength(0) / 2, data.GetLength(1) / 2];
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    if (x != 0 && y != 0)
                        distances.Add(Math.Abs(center - data[x, y]));
                }
            }

            return distances.Average();
        }

        private static void RoundPoints(double[,] data, float roundTo)
        {
            var comp = roundTo / 2;
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    var mod = data[x, y] % roundTo;
                    var dif = roundTo - mod;

                    if (mod >= comp)
                        data[x, y] += dif;
                    else data[x, y] -= mod;
                }
            }
        }

        private static void SquashPoints(double[,] data, GeneratorRequest request)
        {
            switch(request.SquashOption)
            {
                case SquashType.Compress:
                    for (int i = 0; i < request.SquashCompressPasses; i++)
                        CompressPoints(data);
                    break;
                case SquashType.Flatten:
                        FlattenPoints(data, request.SquashFlattenMin, request.SquashFlattenMax);
                    break;
            }
        }

        private static void CompressPoints(double[,] data)
        {
            var avgabove = GetAvgHeightAboveFifty(data);
            var mod = 1 - avgabove;

            for (int x = 0; x < data.GetLength(0); x++)
                for (int y = 0; y < data.GetLength(1); y++)
                        data[x, y] *= mod;
        }

        private static double GetAvgHeightAboveFifty(double[,] data)
        {
            double avg = 0;
            int i = 0;
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    if (data[x, y] > 50.0)
                    {
                        if (i++ > 0)
                            avg = (avg + (data[x, y] - 50)) / 2.0;
                        else
                            avg = data[x, y] - 50;
                    }
                }
            }

            return avg;
        }

        private static void FlattenPoints(double[,] data, double min, double max)
        {
            for (int x = 0; x < data.GetLength(0); x++)
                for (int y = 0; y < data.GetLength(1); y++)
                    if (data[x, y] < min)
                        data[x, y] = min;
                    else if (data[x, y] > max)
                        data[x, y] = max;
        }

        private static double[,] RotatePoints(double[,] data)
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

        private static byte[] GetHeightmapByteArray(double[,] data, GeneratorRequest request)
        {
            //var stride = request.Width * 2;

            //var end = stride % 4;

            //while(end != 0)
            //{
            //    stride += 4 / end;
            //    end = stride % 4;
            //}
            
            byte[] bytes = new byte[data.Length * 2];
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (BinaryWriter writer = new BinaryWriter(ms))
                {
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

                    return bytes;
                }
            }
        }

        private static (double, double, double) GetWaterHeights(double[,] final, double[,] rawData)
        {
            double depthHeight = 0.0;
            double abyssHeight = 0.0;

            var percent = GetPercentWater(rawData);
            var waterHeight = GetValueOfPercent(percent, final);

            var waterPoints = GetAllPointsBelow(final, waterHeight);

            if(waterPoints.Count <= 0)
                return (waterHeight, depthHeight, abyssHeight);

            waterPoints.Sort();

            var thirtythird = .33 * waterPoints.Count;

            var rtt = (int)Math.Round(thirtythird);

            abyssHeight = waterPoints[rtt];

            var sixtysix = .66 * waterPoints.Count;

            var rss = (int)Math.Round(sixtysix);

            depthHeight = waterPoints[rss];

            return (waterHeight, depthHeight, abyssHeight);
        }

        private static double GetValueOfPercent(double percent, double[,] data)
        {
            var minmax = GetMinMax(data);

            var dif = minmax.Item2 - minmax.Item1;

            return percent * dif;
        }

        private static double GetPercentWater(double[,] rawData)
        {
            var minmax = GetMinMax(rawData);

            var bot = Math.Abs(minmax.Item1);
            var dif = minmax.Item2 - minmax.Item1;

            return bot / dif;
        }

        private static List<double> GetAllPointsBelow(double[,] data, double cap)
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

        private static double[,] ConvertElevationToHeightmapValues(double[,] elevation, GeneratorRequest request)
        {
            // Get the average distance from zero ...
            var average = GetAverageDistFromZero(elevation);
            // ... Shift the dataset by the inverse of that ...
            var shiftedSet = ShiftPoints(elevation, 0 - average);
            // ... Squish the set so its min and max are close to a difference of 50 ...
            var squishedSet = SquishPoints(shiftedSet, request.SquishPercent, 50);
            // ... get the new min and max ...
            var minmax = GetMinMax(squishedSet);

            double[,] zeroedSet;
            switch(request.WaterOption)
            {
                case WaterType.Automatic:
                    // ... and zero the data set by shifting it by the inverse of the min ...
                    zeroedSet = ShiftPoints(squishedSet, -minmax.Item1);
                    break;
                case WaterType.Flatten:
                    zeroedSet = DropNegatives(squishedSet);
                    break;
                default:
                    throw new ArgumentNullException(nameof(request.WaterOption), "Water Option can't be null");
            }

            return zeroedSet;
        }

        private static double[,] DropNegatives(double[,] squished)
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

        private static double[,] SquishPoints(double[,] shifted, int squish, double goalpoint)
        {
            var xw = shifted.GetLength(0);
            var yw = shifted.GetLength(1);
            var data = new double[xw, yw];
            Array.Copy(shifted, data, shifted.Length);

            float squishPercentage = squish / 100f;

            int emergencybreak = 0;
            var below = GetBelowThreshold(data, goalpoint);
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

                below = GetBelowThreshold(data, goalpoint);
            }

            return data;
        }

        private static (double, double) GetBelowAboveAverages(double[,] data)
        {
            var counts = GetAboveBelowZeroCounts(data);

            double below = (double)counts.Item2 / data.Length;
            double above = (double)counts.Item1 / data.Length;

            return (below, above);
        }

        private static double GetBelowThreshold(double[,] data, double goalpoint)
        {
            var goals = GetThresholdGoals(data, goalpoint);

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

        private static (double, double) GetThresholdGoals(double[,] data, double goalpoint)
        {
            var counts = GetAboveBelowZeroCounts(data);

            double belowZeroPercentage = (double)counts.Item1 / data.Length;

            double mingoal = -(goalpoint * belowZeroPercentage);
            double maxgoal = goalpoint * (1 - belowZeroPercentage);

            return (mingoal, maxgoal);
        }

        private static (double, double) GetMinMax(double[,] set)
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

        private static (int, int) GetAboveBelowZeroCounts(double[,] set)
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

        private static double[,] ShiftPoints(double[,] elevation, double shift)
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

        private static double GetAverageDistFromZero(double[,] elevation)
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

        private static async Task<double[,]> ReadElevationDatasetAsync(string file, int width, int height)
        {
            string data;
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {

                    // we dont want the first line.
                    _ = await sr.ReadLineAsync();
                    // the data is on the second line.
                    data = await sr.ReadLineAsync();
                }
            }

            if (data is null)
            {
                // TODO: Log no data
                return null;
            }

            var parts = data.Split(',');

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

        private static GlobalPosition[,] GetElevationPoints(GeneratorRequest request)
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

        private static GlobalPosition[,] BuildPointsList(GeneratorRequest request, GlobalPosition initial, GlobalPosition[] bounds)
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

        private static GlobalPosition[,] BuildOffsetTree(GlobalPosition initial, double width, double height, GeneratorRequest request)
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
                    tree[xc, yc++] = new GlobalPosition()
                    {
                        Latitude = y * ySplit,
                        Longitude = x * xSplit
                    };
                }
                xc++;
            }

            return tree;
        }

        private static GlobalPosition[] GetBounds(GlobalPosition initial, int realWidth, int realHeight)
        {
            GlobalPosition[] bounds = new GlobalPosition[2];

            var top = initial.Displace(0, realHeight / 2);
            GlobalPosition left;
            if (realWidth == realHeight)
                left = new GlobalPosition()
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
