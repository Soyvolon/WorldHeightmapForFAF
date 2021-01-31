using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WorldHeightmapCore.Http
{
    public class ElevationClient
    {
        private readonly HttpClient _client;

        public const int URL_MAX_LENGTH = 8192;
        private string? ApiKey { get; set; }

        public ElevationClient(HttpClient client)
        {
            _client = client;
        }

        public void Initialize(string apiKey)
            => ApiKey = apiKey;

        public async Task<IReadOnlyList<double>> GetElevationData(List<Tuple<double, double>> coordPairs)
        {
            if (ApiKey is null) throw new NotInitializedException("Client must be initialized.");

            throw new NotImplementedException();
        }

        private string ComputePolyline(Tuple<double, double> coord)
        {
            throw new NotImplementedException();
        }
    }

    public class NotInitializedException : Exception
    {
        public NotInitializedException() : base() { }
        public NotInitializedException(string? message) : base(message) { }
    }
}
