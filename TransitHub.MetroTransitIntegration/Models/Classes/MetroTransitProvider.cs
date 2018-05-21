using System;
using System.Collections.Generic;
using System.Text;

namespace TransitHub.MetroTransitIntegration.Models
{
    public class MetroTransitProvider
    {
        public int Id { get; }
        public string Name { get; }

        public MetroTransitProvider(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return $"Metro Transit Provider #{Id} : {Name}"; 
        }
    }
}
