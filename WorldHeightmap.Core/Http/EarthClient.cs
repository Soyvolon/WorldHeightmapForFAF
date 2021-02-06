using System;
using System.Net.Http;

namespace WorldHeightmap.Core.Http
{
    public class EarthClient
    {
        private readonly HttpClient _client;

        public EarthClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://earthengine.googleapis.com/v1beta");
        }


    }
}
