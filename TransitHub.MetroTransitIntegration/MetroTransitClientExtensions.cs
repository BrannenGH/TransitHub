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
            return MetroTransitClient.Client.GetDirectionForRouteAsync(route).Result;
        }

        public static IList<MetroTransitStop> GetStops(this MetroTransitRoute route, MetroTransitDirection direction)
        {
            return MetroTransitClient.Client.GetStopsForDirectionAsync(route, direction).Result;
        }

        public static IList<MetroTransitVehicle> GetVehicles(this MetroTransitRoute route)
        {
            return MetroTransitClient.Client.GetBusLocationsAsync(route).Result;
        }
    }
}
