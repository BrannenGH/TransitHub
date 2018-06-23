using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TransitHub.MetroTransitIntegration.Models;

[assembly: CLSCompliant(true)]
namespace TransitHub.MetroTransitIntegration
{
    public class MetroTransitClient
    {
        //Singleton instance of the metro transit client
        private static MetroTransitClient _client;
        public static MetroTransitClient Client
        {
            get
            {
                if (_client == null)
                {
                    //Configure a client with default options
                    _client = new MetroTransitClient();
                }
                return _client;
            }
        }

        private MetroTransitClient() { }

        public async Task<IEnumerable<MetroTransitProvider>> GetProvidersAsync()
        {
            Uri uri = new Uri("http://svc.metrotransit.org/nextrip/providers?format=json");
            string body = await GetBodyForUriAsync(uri);
            IList<MetroTransitProvider> providers = JsonConvert.DeserializeObject<List<MetroTransitProvider>>(body);
            return providers;
        }

        public async Task<IList<MetroTransitRoute>> GetRoutesAsync()
        {
            Uri uri = new Uri("http://svc.metrotransit.org/nextrip/routes?format=json");
            string body = await GetBodyForUriAsync(uri);
            IList<MetroTransitRoute> routes = JsonConvert.DeserializeObject<List<MetroTransitRoute>>(body);
            return routes;
        }

        public async Task<IList<MetroTransitDirection>> GetDirectionForRouteAsync(MetroTransitRoute route)
        {
            Uri uri = new Uri($"http://svc.metrotransit.org/NexTrip/Directions/{route.Id}?format=json");
            string body = await GetBodyForUriAsync(uri);
            JArray directions = JArray.Parse(body);
            return directions.Children()
                   .Select(x => (MetroTransitDirection) (int) x["Value"])
                   .ToList();
        }

        public async Task<IList<MetroTransitStop>> GetStopsForDirectionAsync(MetroTransitRoute route, MetroTransitDirection direction)
        { 
            Uri uri = new Uri($"http://svc.metrotransit.org/NexTrip/Stops/{route.Id}/{(int)direction}?format=json");
            string body = await GetBodyForUriAsync(uri);
            IList<MetroTransitStop> stops = JsonConvert.DeserializeObject<List<MetroTransitStop>>(body);
            return stops;
        }

        public async Task<IList<MetroTransitVehicle>> GetBusLocationsAsync(MetroTransitRoute route)
        {
            Uri uri = new Uri($"http://svc.metrotransit.org/NexTrip/VehicleLocations/{route.Id}?format=json");
            string body = await GetBodyForUriAsync(uri);
            IList<MetroTransitVehicle> buses = JsonConvert.DeserializeObject<List<MetroTransitVehicle>>(body);
            return buses;
        }

        /// <summary>
        /// Sends a GET request to the URI and returns the body of the
        /// response.
        /// </summary>
        /// <param name="uri">The uri to send the GET request to</param>
        /// <returns>
        ///     The body of the HTTP response
        /// </returns>
        private async Task<string> GetBodyForUriAsync(Uri uri)
        {
            //Create webrequest
            WebRequest req = WebRequest.Create(uri);
            WebResponse res = await req.GetResponseAsync();

            //Read the response into an XmlReader
            Stream incoming = res.GetResponseStream();
            StreamReader body = new StreamReader(incoming);
            return await body.ReadToEndAsync(); 
        }
    }
}
