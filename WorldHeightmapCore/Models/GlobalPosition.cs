﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace WorldHeightmapCore.Models
{
    public class GlobalPosition : IEquatable<GlobalPosition>
    {
        public const double EARTH_RADIUS = 6371000;

        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lng")]
        public double Longitude { get; set; }

        public GlobalPosition()
        {

        }

        /// <summary>
        /// Displace a LatLng theta degrees counterclockwise and some meteres in that direction.
        /// </summary>
        /// <param name="theta">Degrees clockwise, where 0 is directly north.</param>
        /// <param name="distance">A distance in meters</param>
        /// <returns>A new GlobalPosition</returns>
        public GlobalPosition Displace(double theta, int distance)
        {
            var delta = distance / EARTH_RADIUS;

            var thetaRads = ToRadians(theta);
            var lat = ToRadians(Latitude);
            var lng = ToRadians(Longitude);

            var lat2 = Math.Asin(Math.Sin(lat) * Math.Cos(delta) 
                + Math.Cos(lat) * Math.Sin(delta) * Math.Cos(thetaRads));

            var lng2 = lng + Math.Atan2(Math.Sin(thetaRads) * Math.Sin(delta) * Math.Cos(lat),
                    Math.Cos(delta) - Math.Sin(lat) * Math.Sin(lat2));

            lng2 = (lng2 + 3 * Math.PI) % (2 * Math.PI) - Math.PI;

            return new GlobalPosition() 
            { 
                Latitude = ToDegrees(lat2),
                Longitude = ToDegrees(lng2)
            };
        }

        public override bool Equals(object? obj)
        {
            if (obj is GlobalPosition pos)
                return Equals(pos);
            else return false;
        }

        public bool Equals(GlobalPosition? other)
        {
            if (other is null) return false;

            return this.Latitude.Equals(other.Latitude)
                && this.Longitude.Equals(other.Longitude);
        }

        public static GlobalPosition operator +(GlobalPosition a, GlobalPosition b)
            => new() { Latitude = a.Latitude + b.Latitude, Longitude = a.Longitude + b.Longitude };

        public static GlobalPosition operator -(GlobalPosition a, GlobalPosition b)
            => new() { Latitude = a.Latitude - b.Latitude, Longitude = a.Longitude - b.Longitude };

        public static double ToDegrees(double val)
            => (val * 180) / Math.PI;

        public static double ToRadians(double val)
            => (val * Math.PI) / 180;

        public static bool TryParseDegrees(string value, [NotNullWhen(true)] out double degrees)
        {
            if (double.TryParse(value, out degrees))
                return true;

            var dSign = value.IndexOf((char)176);

            if (dSign == -1) return false;

            var dString = value.Substring(0, dSign);
            value = value.Remove(0, dSign + 1);

            if (!double.TryParse(dString, out degrees))
                return false;

            var mSign = value.IndexOf((char)39);

            if(mSign > -1)
            {
                var mString = value.Substring(0, mSign);
                value = value.Remove(0, mSign + 1);

                if(double.TryParse(mString, out var minutes))
                {
                    degrees += minutes / 60;
                }
            }

            var sSign = value.IndexOf((char)34);

            if(sSign > -1)
            {
                var sString = value.Substring(0, sSign);
                value = value.Remove(0, sSign + 1);

                if (double.TryParse(sString, out var minutes))
                {
                    degrees += minutes / 3600;
                }
            }

            value = value.Trim().ToUpper();
            bool positive = value switch
            {
                "N" => true,
                "W" => false,
                "S" => false,
                "E" => true,
                _ => true
            };

            if (!positive)
                degrees *= -1;

            return true;
        }
    }
}
