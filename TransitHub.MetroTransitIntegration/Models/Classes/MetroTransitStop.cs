using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TransitHub.Shared.Models;

namespace TransitHub.MetroTransitIntegration.Models
{
    public class MetroTransitStop
    {
        [JsonProperty(PropertyName = "text")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "value")]
        public string Id { get; private set; }
    }
}
