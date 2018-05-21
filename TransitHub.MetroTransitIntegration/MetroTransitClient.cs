using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TransitHub.MetroTransitIntegration.Models;

namespace TransitHub.MetroTransitIntegration
{
    public class MetroTransitClient
    {
        private HttpClient client;

        public MetroTransitClient()
        {
            client = new HttpClient();
        }

        public MetroTransitClient(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException("Client cannot be null.");
        }

        public async Task<IList<MetroTransitProvider>> GetProvidersAsync()
        {
            HttpResponseMessage res = 
                await client.GetAsync("http://svc.metrotransit.org/NexTrip/Providers?format=json");
            string body = await res.Content.ReadAsStringAsync();

            JArray parsedBody = JArray.Parse(body);
            IList<MetroTransitProvider> providers =
                parsedBody.Select(field => 
                    new MetroTransitProvider(
                        (string) field["Text"],
                        (int) field["Value"]
                    )
                ).ToList();
            return providers;
        }

        public async Task<IList<MetroTransitRoute>> GetRoutesAsync()
        {
            HttpResponseMessage res = 
                await client.GetAsync("http://svc.metrotransit.org/NexTrip/Routes?format=json");
            string body = await res.Content.ReadAsStringAsync();

            JArray parsedBody = JArray.Parse(body);
            if (String.IsNullOrWhiteSpace(body) || parsedBody == null)
            {
                throw new Exception("Could not parse body of request");
            }

            IList<MetroTransitRoute> routes =
                parsedBody.Select(field => 
                    new MetroTransitRoute(
                        (int) field["Route"],
                        (int) field["ProviderID"],
                        (string) field["Description"]
                    )
                ).ToList();
            return routes;
        }
    }
}
