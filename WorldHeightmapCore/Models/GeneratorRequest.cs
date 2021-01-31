using System.Diagnostics.CodeAnalysis;

namespace WorldHeightmapCore.Models
{
    public class GeneratorRequest
    {
        public double Latitude { get; internal set; }
        public double Longitude { get; internal set; }
        public int Width { get; internal set; }
        public int Height { get; internal set; }
        public WaterType WaterOption { get; internal set; }
        public float WaterElevation { get; internal set; }
        public float DepthElevation { get; internal set; }
        public float AbyssElevation { get; internal set; }
        public SquashType SquashOption { get; internal set; }
        public int SquashCompressPasses { get; internal set; }
        public int SquashFlattenMin { get; internal set; }
        public int SquashFlattenMax { get; internal set; }
        public Smoothing SmoothingOptions { get; internal set; }
        public int AverageSmoothingPasses { get; internal set; }
        public float AverageSmoothingMaxDifference { get; internal set; }
        public float RoundSmoothingNearest { get; internal set; }
    }

    public enum WaterType
    {
        Manual,
        Automatic,
        None
    }

    public enum SquashType
    {
        Compress,
        Flatten,
        None
    }

    public enum Smoothing
    {
        Average,
        Round,
        None
    }
}
