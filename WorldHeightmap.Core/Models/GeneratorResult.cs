using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldHeightmapCore.Models
{
    public class GeneratorResult
    {
        public byte[] Heightmap { get; internal set; }
        public double[,] RawElevationData { get; internal set; }
        public double[,] ModifedElevationData { get; internal set; }
        public double WaterHeight { get; internal set; }
        public double DepthHeight { get; internal set; }
        public double AbyssHeight { get; internal set; }
    }
}
