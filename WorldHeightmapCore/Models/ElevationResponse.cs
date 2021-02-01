using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WorldHeightmapCore.Models
{
    public partial class ElevationResponse
    {
        [JsonProperty("results")]
        public ElevationResult[] Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error_message")]
        public string? ErrorMessage { get; set; }
    }

    public partial class ElevationResult
    {
        [JsonProperty("elevation")]
        public double Elevation { get; set; }

        [JsonProperty("location")]
        public GlobalPosition Location { get; set; }

        [JsonProperty("resolution")]
        public double Resolution { get; set; }
    }

    public partial class ElevationResponse
    {
        public static ElevationResponse? FromJson(string json) => JsonConvert.DeserializeObject<ElevationResponse>(json, ElevationConverter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ElevationResponse self) => JsonConvert.SerializeObject(self, ElevationConverter.Settings);
    }

    internal static class ElevationConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
