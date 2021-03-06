﻿using System;

using WorldHeightmap.Core.Models;

namespace WorldHeightmap.Core.Extensions
{
    public static class GlobalPositionExtenstions
    {
        public static GlobalPosition[,] Round(this GlobalPosition[,] dat, int decimalPlaces)
        {
            var w = dat.GetLength(0);
            var h = dat.GetLength(1);
            GlobalPosition[,] output = new GlobalPosition[w, h];

            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                    output[x, y] = new GlobalPosition()
                    {
                        Latitude = Math.Round(dat[x, y].Latitude, decimalPlaces),
                        Longitude = Math.Round(dat[x, y].Longitude, decimalPlaces)
                    };

            return output;
        }
    }
}
