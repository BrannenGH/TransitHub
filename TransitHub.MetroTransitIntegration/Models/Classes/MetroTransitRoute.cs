using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace TransitHub.MetroTransitIntegration.Models
{

    public enum MetroTransitDirection
    {
        South = 1,
        East,
        West,
        North
    }

    [SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.datacontract.org/2004/07/MetCouncil.Transit.ScheduleData")]
    public class MetroTransitRoute
    {
        [XmlAttribute("Value")]
        public int Id { get; }
        [XmlAttribute("ProviderID")]
        public int ProviderId { get; }
        [XmlAttribute("Name")]
        public string Name { get; }
        private IList<MetroTransitDirection> _directions;
        public IList<MetroTransitDirection> Directions
        {
            get
            {
                if (_directions == null)
                {
                    _directions = null; //this.GetDirectionsAsync(); 
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
