using System.IO;
using Mapsui.Geometries;
using Mapsui.Styles;
using Mapsui.Providers;
using Mapsui.Projection;
using TransitHub.Shared.Interfaces;
using TransitHub.Shared.Helpers;

namespace TransitHub.Shared.Models
{
    public class TransitStop: ITransitStop
    {
        public Point Location { get; }
        public IFeature Feature { get; }
        public SymbolStyle Icon { get; }

        public TransitStop(double lng, double lat)
        {
            Location = new Point(lng, lat);
            Icon = CreateIcon();
            Feature = CreateFeature();
        }

        private IFeature CreateFeature()
        {
            var feature = new Feature();
            var point = SphericalMercator.FromLonLat(Location.X,Location.Y);
            feature.Geometry = point;
            return feature;
        }

        private SymbolStyle CreateIcon()
        {
            // Image Courtesy of Freepik http://www.freepik.com
            Stream image = IconHelper.GetResourceStream("TransitHub.Shared.Assets.busstop.png");

            return IconHelper.CreateSymbolFromStream(image, 0.05, 125); 
        }
    }
}
