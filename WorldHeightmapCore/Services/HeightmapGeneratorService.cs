using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using WorldHeightmapCore.Http;
using WorldHeightmapCore.Models;

namespace WorldHeightmapCore.Services
{
    public class HeightmapGeneratorService
    {
        private readonly ElevationClient _elevation;

        public HeightmapGeneratorService(ElevationClient elevation)
            => _elevation = elevation;

        /// <summary>
        /// Generate a heightmap from a GeneratorRequest
        /// </summary>
        /// <param name="request">A request to make the heightmap based off of.</param>
        /// <param name="apiKey">The Google Elevation API key</param>
        /// <returns>A MemoryStream of the raw heightmap file</returns>
        public async Task<MemoryStream> GenerateHeightmap(GeneratorRequest request)
        {
            _elevation.Initialize(request.ApiKey);

            var globalPoints = GetElevationPoints(request);

            var elevationPoints = await _elevation.GetElevationData(globalPoints);

            // TODO return real result
            return null;
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
