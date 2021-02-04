using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WorldHeightmapCore.Http
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
