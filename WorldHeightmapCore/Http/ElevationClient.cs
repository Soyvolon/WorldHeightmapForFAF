using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Soyvolon.Utilities.Data;

using WorldHeightmapCore.Models;

namespace WorldHeightmapCore.Http
{
    public class ElevationClient
    {
        private readonly HttpClient _client;

        public const string URL_BASE = "https://maps.googleapis.com/maps/api/elevation/json?key=";
        public const int URL_MAX_LENGTH = 8192;
        private string? ApiKey { get; set; }

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

            List<ElevationResponse?> responses = new();
            List<Task> toAwait = new();

            for(int i = 0; i < requests.Count; i++)
            {
                toAwait.Add(Task.Run(async () =>
                {
                    try
                    {
                        if (requests.TryDequeue(out var request))
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
                                responses.Add(new()
                                {
                                    ErrorMessage = $"{response.StatusCode}: {response.ReasonPhrase}",
                                    Status = "ERRORED"
                                });
                            }
                        }
                        else
                        {
                            responses.Add(new()
                            {
                                ErrorMessage = "Failed to remove a request from the Queue when there should have been one.",
                                Status = "ERRORED"
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        responses.Add(new()
                        {
                            ErrorMessage = ex.Message,
                            Status = "ERRORED"
                        });
                    }
                }));
            }

            foreach (var task in toAwait)
                await task;

            List<ElevationResult> results = new();

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

            for(int x = 0; x < w; x++)
            {
                for(int y = 0; y < h; y++)
                {
                    var p = points[x, y];

                    var res = results.FirstOrDefault(z => z.Location.Equals(p));

                    if (res is null)
                        throw new ElevationApiException("A returned point did not match a requested point.");

                    elevation[x, y] = res.Elevation;
                }
            }

            return elevation;
        }

        private ConcurrentQueue<string> GetRequests(List<GlobalPosition> polyPoints)
        {
            var baseUrl = URL_BASE + ApiKey + "&locations=enc:";

            ConcurrentQueue<string> requests = new();

            string current = baseUrl;
            GlobalPosition last = new();
            foreach(var poly in polyPoints)
            {
                string toAdd = ComputePolyline(poly, last);
                last = poly;

                if(current.Length + toAdd.Length > URL_MAX_LENGTH)
                {
                    requests.Enqueue(current);
                    current = baseUrl;
                    last = new();
                    toAdd += ComputePolyline(poly, last);
                }

                current += toAdd;
            }

            requests.Enqueue(current);

            return requests;
        }

        private List<GlobalPosition> GetPolylinePoints(GlobalPosition[,] points)
        {
            List<GlobalPosition> polyPoints = new();
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
        public NotInitializedException(string? message) : base(message) { }
    }

    public class ElevationApiException : Exception
    {
        public ElevationApiException() : base() { }
        public ElevationApiException(string? message) : base(message) { }
    }
}
