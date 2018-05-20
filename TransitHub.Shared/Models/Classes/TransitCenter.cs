using System.Linq;
using System.Collections.Generic;
using Mapsui.Geometries;
using Mapsui.Layers;
using Mapsui.Providers;
using TransitHub.Shared.Interfaces;

namespace TransitHub.Shared.Models
{
    public class TransitCenter : ITransitHub
    {
        public IEnumerable<ITransitStop> Stops { get; }
        public Point Location { get; }

        public TransitCenter(double lng, double lat, IEnumerable<ITransitStop> stops)
        {
            Location = new Point(lng, lat);
            Stops = stops;
        }

        public MemoryLayer CreateStopLayer()
        {
            var _stopEnumerator = Stops.GetEnumerator();
            _stopEnumerator.MoveNext();

            return new MemoryLayer
            {
                //Todo: Have each stop have it's own style
                //Todo: Not have application fail when Stops is empty
                Name = "Locations",
                DataSource = new MemoryProvider(Stops.Select(i => i.Feature)),
                Style = _stopEnumerator.Current.Icon
            };
        }
    }
}
