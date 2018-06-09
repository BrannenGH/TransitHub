using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TransitHub.MetroTransitIntegration.Models
{
    public class MetroTransitProvider
    {
        [XmlAttribute("Value")]
        public int Id { get; }

        [XmlAttribute("Text")]
        public string Name { get; }

        public override string ToString()
        {
            return $"Metro Transit Provider #{Id} : {Name}"; 
        }
    }
}
