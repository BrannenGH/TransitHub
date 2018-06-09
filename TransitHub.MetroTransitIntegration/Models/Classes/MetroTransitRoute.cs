using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TransitHub.MetroTransitIntegration.Models
{

    public enum MetroTransitDirection
    {
        South = 1,
        East,
        West,
        North
    }

    public class MetroTransitRoute
    {
        [JsonProperty(PropertyName = "Route")]
        public virtual int Id { get; private set; }

        [JsonProperty(PropertyName = "ProviderID")]
        public int ProviderId { get; private set; }

        [JsonProperty(PropertyName = "Description")]
        public string Name { get; private set; }

        private IList<MetroTransitDirection> _directions;
        public IList<MetroTransitDirection> Directions
        {
            get
            {
                if (_directions == null)
                {
                    _directions = this.GetDirections(); 
                }
                return _directions;
            }
        }

        public override string ToString()
        {
            return $"Metro Transit Route #{Id} : {Name}"; 
        }
    }
}
