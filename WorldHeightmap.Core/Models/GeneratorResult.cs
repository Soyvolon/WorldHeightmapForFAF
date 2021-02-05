using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldHeightmap.Core.Models
{
    public class GeneratorResult
    {
        public byte[] Heightmap { get; internal set; }
        public double[,] RawElevationData { get; internal set; }
        public double[,] ModifedElevationData { get; internal set; }
        public double WaterHeight { get; internal set; }
        public double DepthHeight { get; internal set; }
        public double AbyssHeight { get; internal set; }

        public GeneratorResult Clone()
        {
            var res = new GeneratorResult()
            {
                WaterHeight = WaterHeight,
                DepthHeight = DepthHeight,
                AbyssHeight = AbyssHeight
            };

            res.Heightmap = (byte[])Heightmap.Clone();
            res.RawElevationData = (double[,])RawElevationData.Clone();
            res.ModifedElevationData = (double[,])ModifedElevationData.Clone();

            return res;
        }
    }
}
