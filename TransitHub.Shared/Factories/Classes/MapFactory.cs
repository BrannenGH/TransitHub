using Mapsui;
using Mapsui.Projection;
using Mapsui.Utilities;
using System;
using TransitHub.Shared.Interfaces;

namespace TransitHub.Shared.Models
{
    public class MapFactory: IMapFactory
    {
        public Map CreateMap(ITransitHub hub)
        {
            var map = new Map();
            map.Layers.Add(OpenStreetMap.CreateTileLayer());
            map.Layers.Add(hub.CreateStopLayer());

            map.NavigateTo(map.Resolutions[14]);
            map.NavigateTo(SphericalMercator.
                           FromLonLat(hub.Location.X,
                                      hub.Location.Y));
            return map;
        }


        public Map CreateMap(ITransitLocation stop)
        {
            var map = new Map();
            map.Layers.Add(OpenStreetMap.CreateTileLayer());


            map.NavigateTo(map.Resolutions[14]);
            map.NavigateTo(SphericalMercator.
                           FromLonLat(stop.Location.X,
                                      stop.Location.Y));
            return map;
        }
    }
}
