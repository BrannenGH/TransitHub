using Mapsui;
using Mapsui.Projection;
using Mapsui.Utilities;
using System;
using TransitHub.Shared.Interfaces;

namespace TransitHub.Shared.Models
{
    public class MapFactory: IMapFactory
    {
        public Map CreateMap(ITransitStop stop)
        {
            var map = new Map();
            map.Layers.Add(OpenStreetMap.CreateTileLayer());

            map.NavigateTo(map.Resolutions[9]);
            var temp = SphericalMercator.
                           FromLonLat(stop.GetLocation().X,
                                      stop.GetLocation().Y);
            map.NavigateTo(temp);
            return map;
        }
    }
}
