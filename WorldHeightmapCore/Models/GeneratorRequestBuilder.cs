using System;
using System.Collections.Generic;
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
        public float WaterElevation { get; set; } = 0.0f;
        public float DepthElevation { get; set; } = 0.0f;
        public float AbyssElevation { get; set; } = 0.0f;
        public SquashType SquashOption { get; set; } = SquashType.Compress;
        public int SquashCompressPasses { get; set; } = 3;
        public int SquashFlattenMin { get; set; } = 5;
        public int SquashFlattenMax { get; set; } = 55;
        public Smoothing SmoothingOptions { get; set; } = Smoothing.Average;
        public int AverageSmoothingPasses { get; set; } = 3;
        public float AverageSmoothingMaxDifference { get; set; } = 0.0035f;
        public float RoundSmoothingNearest { get; set; } = 0.50f;

        public GeneratorRequestBuilder()
        {
            
        }

        public GeneratorRequestBuilder WithApiKey(string apiKey)
        {
            ApiKey = apiKey;
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

        public GeneratorRequestBuilder WithWidht(int width)
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

        public GeneratorRequestBuilder WithNoWater()
        {
            WaterOption = WaterType.None;
            return this;
        }

        public GeneratorRequestBuilder WithManualWater(float water, float depth, float abyss)
        {
            WaterElevation = water;
            DepthElevation = depth;
            AbyssElevation = abyss;
            WaterOption = WaterType.Manual;
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

        public GeneratorRequestBuilder WithAverageSmoothing(int passes, float maxDiff)
        {
            AverageSmoothingPasses = passes;
            AverageSmoothingMaxDifference = maxDiff;
            SmoothingOptions = Smoothing.Average;
            return this;
        }

        public GeneratorRequestBuilder WithRoundSmoothing(float nearest)
        {
            RoundSmoothingNearest = nearest;
            SmoothingOptions = Smoothing.Round;
            return this;
        }

        public GeneratorRequestBuilder WithNoSmoothing()
        {
            SmoothingOptions = Smoothing.None;
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
                WaterElevation = WaterElevation,
                DepthElevation = DepthElevation,
                AbyssElevation = AbyssElevation,
                SquashOption = SquashOption,
                SquashCompressPasses = SquashCompressPasses,
                SquashFlattenMin = SquashFlattenMin,
                SquashFlattenMax = SquashFlattenMax,
                SmoothingOptions = SmoothingOptions,
                AverageSmoothingPasses = AverageSmoothingPasses,
                AverageSmoothingMaxDifference = AverageSmoothingMaxDifference,
                RoundSmoothingNearest = RoundSmoothingNearest
            };
        }
    }
}
