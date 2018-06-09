using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TransitHub.MetroTransitIntegration.Models
{
    public class MetroTransitProvider
    {
        [JsonProperty(PropertyName = "value")]
        public int Id { get; private set; }

        [JsonProperty(PropertyName = "text")]
        public string Name { get; private set; }

        public override string ToString()
        {
            return $"Metro Transit Provider #{Id} : {Name}"; 
        }
    }
}
