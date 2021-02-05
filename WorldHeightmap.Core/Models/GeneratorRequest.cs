using System.Diagnostics.CodeAnalysis;

namespace WorldHeightmapCore.Models
{
    public class GeneratorRequest
    {
        public string ApiKey { get; internal set; }
        public double Latitude { get; internal set; }
        public double Longitude { get; internal set; }
        public int Width { get; internal set; }
        public int KilometerWidth { get; internal set; }
        public int Height { get; internal set; }
        public int KilometerHeight { get; internal set; }
        public WaterType WaterOption { get; internal set; }
        public SquashType SquashOption { get; internal set; }
        public int SquashCompressPasses { get; internal set; }
        public int SquashFlattenMin { get; internal set; }
        public int SquashFlattenMax { get; internal set; }
        public Smoothing SmoothingOptions { get; internal set; }
        public int AverageSmoothingPasses { get; internal set; }
        public int SmoothFWHM { get; internal set; }
        public float RoundSmoothingNearest { get; internal set; }
        public bool ElevationData { get; internal set; }
        public string DataFileLocation { get; internal set; }
        public int SquishPercent { get; internal set; }
        public bool EarthEngine { get; internal set; }
        public int KernelSize { get; internal set; }
    }

    public enum WaterType
    {
        Flatten,
        Automatic
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
