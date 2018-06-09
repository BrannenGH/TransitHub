using System;
using System.Collections.Generic;
using System.Text;
using TransitHub.MetroTransitIntegration.Models;

namespace TransitHub.MetroTransitIntegration
{
    public static class MetroTransitClientExtensions
    {
        public static IList<MetroTransitDirection> GetDirections(this MetroTransitRoute route)
        {
            return MetroTransitClient.Client.GetDirectionForRoute(route).Result;
        }
    }
}
