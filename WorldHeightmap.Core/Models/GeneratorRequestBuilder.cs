using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WorldHeightmapCore.Models
{
    public class GeneratorRequestBuilder
    {
        public string ApiKey { get; set; } = "";
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;
        public int Width { get; set; } = 256;
        public int KilometerWidth { get; set; } = 5000;
        public int Height { get; set; } = 256;
        public int KilometerHeight { get; set; } = 5000;
        public WaterType WaterOption { get; set; } = WaterType.Automatic;
        public SquashType SquashOption { get; set; } = SquashType.Compress;
        public int SquashCompressPasses { get; set; } = 3;
        public int SquashFlattenMin { get; set; } = 5;
        public int SquashFlattenMax { get; set; } = 55;
        public Smoothing SmoothingOptions { get; set; } = Smoothing.Average;
        public int AverageSmoothingPasses { get; set; } = 3;
        public int SmoothFWHM { get; set; } = 4;
        public float RoundSmoothingNearest { get; set; } = 0.50f;
        public bool ElevationData { get; set; } = false;
        public string DataFileLocation { get; set; } = "";
        public int SquishPercent { get; set; } = 80;
        public bool EarthEngine { get; set; } = false;
        public int KernelSize { get; set; } = 5;

        public GeneratorRequestBuilder()
        {
            
        }

        public GeneratorRequestBuilder WithApiKey(string apiKey)
        {
            ApiKey = apiKey;
            EarthEngine = false;
            return this;
        }

        public GeneratorRequestBuilder WithEarthEngineKey(string eeKey)
        {
            ApiKey = eeKey;
            EarthEngine = true;
            return this;
        }

        public GeneratorRequestBuilder WithLatitude(double latitude)
        {
            Latitude = latitude;
            return this;
        }

        public GeneratorRequestBuilder WithLongitude(double longitude)
        {
            Longitude = longitude;
            return this;
        }

        public GeneratorRequestBuilder WithWidth(int width)
        {
            Width = width;
            return this;
        }

        public GeneratorRequestBuilder WithKilometerWidth(int kilometerWidth)
        {
            KilometerWidth = kilometerWidth;
            return this;
        }

        public GeneratorRequestBuilder WithHeight(int height)
        {
            Height = height;
            return this;
        }

        public GeneratorRequestBuilder WithKilometerHeight(int kilometerHeight)
        {
            KilometerHeight = kilometerHeight;
            return this;
        }

        public GeneratorRequestBuilder WithAutomaticWater()
        {
            WaterOption = WaterType.Automatic;
            return this;
        }

        public GeneratorRequestBuilder WithFlattenWater()
        {
            WaterOption = WaterType.Flatten;
            return this;
        }

        public GeneratorRequestBuilder WithCompressSquash(int passes)
        {
            SquashCompressPasses = passes;
            SquashOption = SquashType.Compress;
            return this;
        }

        public GeneratorRequestBuilder WithFlattenSquash(int min, int max)
        {
            SquashFlattenMin = min;
            SquashFlattenMax = max;
            SquashOption = SquashType.Flatten;
            return this;
        }

        public GeneratorRequestBuilder WithNoSquash()
        {
            SquashOption = SquashType.None;
            return this;
        }

        public GeneratorRequestBuilder WithNormalSmoothing(int passes, int fwhm, int kernelSize)
        {
            if (kernelSize % 2 != 1 || kernelSize <= 1)
                throw new ArgumentException("Size must be odd and larger than 1.", nameof(kernelSize));

            KernelSize = kernelSize;
            AverageSmoothingPasses = passes;
            SmoothFWHM = fwhm;
            SmoothingOptions = Smoothing.Average;
            return this;
        }

        public GeneratorRequestBuilder WithRoundSmoothing(float nearest)
        {
            RoundSmoothingNearest = nearest;
            SmoothingOptions = Smoothing.Round;
            return this;
        }

        public GeneratorRequestBuilder WithCombinedSmoothing(float nearest, int passes, int fwhm, int kernelSize)
        {
            WithNormalSmoothing(passes, fwhm, kernelSize)
                .WithRoundSmoothing(nearest);

            SmoothingOptions = Smoothing.Combined;
            return this;
        }

        public GeneratorRequestBuilder WithNoSmoothing()
        {
            SmoothingOptions = Smoothing.None;
            return this;
        }

        public GeneratorRequestBuilder WithSquishPercent(int percent)
        {
            SquishPercent = percent;
            return this;
        }

        public GeneratorRequestBuilder WithElevationDataset(string datasetFile, string defaultFolder = "")
        {
            ElevationData = true;

            var p = datasetFile;

            if (!Path.IsPathRooted(p))
            {
                p = defaultFolder + p;
            }

            DataFileLocation = p;

            return this;
        }

        public GeneratorRequest Build()
        {
            return new GeneratorRequest()
            {
                ApiKey = ApiKey,
                Latitude = Latitude,
                Longitude = Longitude,
                Width = Width,
                KilometerWidth = KilometerWidth,
                Height = Height,
                KilometerHeight = KilometerHeight,
                WaterOption = WaterOption,
                SquashOption = SquashOption,
                SquashCompressPasses = SquashCompressPasses,
                SquashFlattenMin = SquashFlattenMin,
                SquashFlattenMax = SquashFlattenMax,
                SmoothingOptions = SmoothingOptions,
                AverageSmoothingPasses = AverageSmoothingPasses,
                SmoothFWHM = SmoothFWHM,
                RoundSmoothingNearest = RoundSmoothingNearest,
                ElevationData = ElevationData,
                DataFileLocation = DataFileLocation,
                SquishPercent = SquishPercent,
                EarthEngine = EarthEngine,
                KernelSize = KernelSize
            };
        }
    }
}
