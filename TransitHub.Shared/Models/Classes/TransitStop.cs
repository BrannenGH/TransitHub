using Mapsui.Geometries;
using Mapsui.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using TransitHub.Shared.Interfaces;
using Mapsui.Providers;
using Mapsui.Projection;
using System.IO;

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
            var path = "TransitHub.Shared.Assets.busstop.png"; 

            Stream image = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            if (image == null)
            {
                throw new Exception($"Resource {path} could not be found.");
            }

            var bitmapId = BitmapRegistry.Instance.Register(image);
            
            // To set the offset correct we need to know the bitmap height
            var bitmapHeight = 176; 

            return new SymbolStyle {
                BitmapId = bitmapId,
                SymbolScale = 0.20,
                SymbolOffset = new Offset(0, bitmapHeight * 0.5)
            };
        }
    }
}
