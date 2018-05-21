using System;
using System.Collections.Generic;
using System.Text;

namespace TransitHub.MetroTransitIntegration.Models
{
    public class MetroTransitRoute
    {
        public int Id { get; }
        public int ProviderId { get; }
        public string Name { get; }

        public MetroTransitRoute(int id,
                                 int providerId,
                                 string name)
        {
            Id = id;
            ProviderId = providerId;
            Name = name;
        }

        public override string ToString()
        {
            return $"Metro Transit Route #{Id} : {Name}"; 
        }
    }
}
