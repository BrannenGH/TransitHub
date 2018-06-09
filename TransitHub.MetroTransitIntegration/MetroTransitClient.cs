using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
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
            XmlReader reader = await GetXmlContentForUriAsync(new Uri("http://svc.metrotransit.org/NexTrip/Providers"));
            IEnumerable<MetroTransitProvider> providers = await SerializeXmlArray<MetroTransitProvider>(reader);
            return providers;
        }

        /*public async Task<IList<MetroTransitRoute>> GetRoutesAsync()
        {
            GetXmlContentForUriAsync("http://svc.metrotransit.org/NexTrip/Routes?format=json");
            string body = await res.Content.ReadAsStringAsync();

            JArray parsedBody = JArray.Parse(body);
            if (String.IsNullOrWhiteSpace(body) || parsedBody == null)
            {
                throw new Exception("Could not parse body of request");
            }

            IList<MetroTransitRoute> routes =
            return routes;
        }*/
        
        private async Task<IEnumerable<T>> SerializeXmlArray<T>(XmlReader reader)
            where T: class
        {
            IList<T> array = new List<T>();
            while (!reader.EOF)
            {
                array.Add(await ReadXmlIntoObject<T>(reader));
            }

            return array;
        } 
        
        /// <summary>
        /// Navigates to the provided uri and uses the response stream
        /// to create an XmlReader. The XmlReader is also advanced to the
        /// content part of the XML.
        /// </summary>
        /// <param name="uri">The uri to send the GET request to</param>
        /// <returns>
        ///     An XmlReader positioned at the beginning of the content
        /// </returns>
        private async Task<XmlReader> GetXmlContentForUriAsync(Uri uri)
        {
            //Create webrequest
            WebRequest req = WebRequest.Create(uri);
            WebResponse res = await req.GetResponseAsync();

            //Permit Async XmlReading
            XmlReaderSettings settings = new XmlReaderSettings
            {
                Async = true
            };

            //Read the response into an XmlReader
            using (XmlReader reader = 
                XmlReader.Create(res.GetResponseStream(), settings))
            {
                await reader.MoveToContentAsync();
                return reader;
            }
        }
        
        /// <summary>
        /// Reads the next XML element into an object, T.
        /// </summary>
        /// <param name="reader">An XmlReader pointed at a serialzed version of T</param>
        /// <returns>A deserialized T</returns>
        private async Task<T> ReadXmlIntoObject<T>(XmlReader reader)
            where T : class
        {
            return (T) await reader.ReadContentAsAsync(typeof(T), null);
        }
    }
}
