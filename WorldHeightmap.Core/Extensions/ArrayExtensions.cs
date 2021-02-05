using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldHeightmap.Core.Extensions
{
    public static class ArrayExtensions
    {
        public static void MapCenter<T>(this T[,] data, T[,] map, int x, int y)
        {
            var w = map.GetLength(0);
            var h = map.GetLength(1);

            data.Map(map, x - (w / 2), y - (h / 2));
        }

        public static void Map<T>(this T[,] data, T[,] map, int x, int y)
        {
            for (int mx = 0; mx < map.GetLength(0); mx++)
                for (int my = 0; my < map.GetLength(1); my++)
                    data[x + mx, y + my] = map[mx, my];
        }

        public static void DisplaceCenter(this double[,] data, double[,] displace, int x, int y)
        {
            var w = displace.GetLength(0);
            var h = displace.GetLength(1);

            data.Displace(displace, x - (w / 2), y - (h / 2));
        }

        public static void Displace(this double[,] data, double[,] displace, int x, int y)
        {
            for (int mx = 0; mx < displace.GetLength(0); mx++)
                for (int my = 0; my < displace.GetLength(1); my++)
                    data[x + mx, y + my] += displace[mx, my];
        }
    }
}
