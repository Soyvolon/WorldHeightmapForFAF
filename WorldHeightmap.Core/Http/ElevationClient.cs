using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Soyvolon.Utilities.Data;

using WorldHeightmap.Core.Models;

namespace WorldHeightmap.Core.Http
{
    public class ElevationClient
    {
        private readonly HttpClient _client;

        public const string URL_BASE = "https://maps.googleapis.com/maps/api/elevation/json?key=";
        public const int URL_MAX_LENGTH = 8192;
        public const int POINTS_PER_REQUEST = 512;

        private string ApiKey { get; set; }

        public ElevationClient(HttpClient client)
        {
            _client = client;
        }

        public void Initialize(string apiKey)
            => ApiKey = apiKey;

        public async Task<double[,]> GetElevationData(GlobalPosition[,] points)
        {
            if (ApiKey is null) throw new NotInitializedException("Client must be initialized.");

            var polyPoints = GetPolylinePoints(points);

            var requests = GetRequests(polyPoints);

            List<ElevationResponse> responses = new List<ElevationResponse>();

            int i = 0;
            while(requests.TryDequeue(out var request))
            {
                if (i++ > 0)
                    await Task.Delay(TimeSpan.FromSeconds(.25));

                try
                {
                    var response = await _client.GetAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        var obj = ElevationResponse.FromJson(json);

                        responses.Add(obj);
                    }
                    else
                    {
                        responses.Add(new ElevationResponse()
                        {
                            ErrorMessage = $"{response.StatusCode}: {response.ReasonPhrase}",
                            Status = "CLIENT_ERRORED"
                        });

                        break;
                    }
                }
                catch (Exception ex)
                {
                    responses.Add(new ElevationResponse()
                    {
                        ErrorMessage = ex.Message,
                        Status = "CLIENT_ERRORED"
                    });

                    break;
                }
            }

            List<ElevationResult> results = new List<ElevationResult>();

            foreach (var r in responses)
            {
                if (r is null || !r.Status.Equals("OK"))
                    throw new ElevationApiException($"A request to the API failed: {r?.ErrorMessage ?? "An Unkown Error occoured."}");

                results.AddRange(r.Results);
            }

            var elevationPoints = GetOrderedElevationData(results, points);

            return elevationPoints;
        }

        private double[,] GetOrderedElevationData(List<ElevationResult> results, GlobalPosition[,] points)
        {
            int w = points.GetLength(0);
            int h = points.GetLength(1);

            double[,] elevation = new double[w, h];

            int i = 0;
            for(int x = 0; x < w; x++)
            {
                for(int y = 0; y < h; y++)
                {
                    var res = results[i++];
                    // We assume the order is the same.
                    elevation[x, y] = res.Elevation;
                }
            }

            return elevation;
        }

        private ConcurrentQueue<string> GetRequests(List<GlobalPosition> polyPoints)
        {
            var baseUrl = URL_BASE + ApiKey + "&locations=enc:";

            ConcurrentQueue<string> requests = new ConcurrentQueue<string>();

            string current = baseUrl;
            GlobalPosition last = new GlobalPosition();
            int c = 0;
            foreach(var poly in polyPoints)
            {
                string toAdd = ComputePolyline(poly, last);

                if(current.Length + toAdd.Length > URL_MAX_LENGTH || c++ >= POINTS_PER_REQUEST)
                {
                    requests.Enqueue(current);
                    current = baseUrl;
                    last = new GlobalPosition();
                    c = 1;
                    toAdd = ComputePolyline(poly, last);
                }

                last = poly;
                current += toAdd;
            }

            requests.Enqueue(current);

            return requests;
        }

        private List<GlobalPosition> GetPolylinePoints(GlobalPosition[,] points)
        {
            List<GlobalPosition> polyPoints = new List<GlobalPosition>();
            for (int x = 0; x < points.GetLength(0); x++)
                for (int y = 0; y < points.GetLength(1); y++)
                    polyPoints.Add(points[x, y]);

            return polyPoints;
        }

        private static string ComputePolyline(GlobalPosition point, GlobalPosition last)
            => GooglePolylineEncoder.Encode(point.Latitude - last.Latitude, point.Longitude - last.Longitude);
    }

    public class NotInitializedException : Exception
    {
        public NotInitializedException() : base() { }
        public NotInitializedException(string message) : base(message) { }
    }

    public class ElevationApiException : Exception
    {
        public ElevationApiException() : base() { }
        public ElevationApiException(string message) : base(message) { }
    }
}
