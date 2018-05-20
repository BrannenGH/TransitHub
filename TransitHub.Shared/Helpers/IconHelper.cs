using Mapsui.Styles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace TransitHub.Shared.Helpers
{
    static class IconHelper
    {
        public static Stream GetResourceStream(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            if (stream == null)
            {
                throw new Exception($"Resource {path} could not be found.");
            }
            return stream;
        }

        public static SymbolStyle CreateSymbolFromStream(Stream stream, double scale, int height)
        {
            var bitmapId = BitmapRegistry.Instance.Register(stream);
            
            // To set the offset correct we need to know the bitmap height
            var bitmapHeight = 176; 

            return new SymbolStyle {
                BitmapId = bitmapId,
                SymbolScale = scale,
                SymbolOffset = new Offset(0, bitmapHeight * 0.5)
            };
        }
    }
}
