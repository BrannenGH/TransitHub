using System;
using System.Collections.Generic;
using System.Text;
using Mapsui.Geometries;
using TransitHub.Shared.Interfaces;

namespace TransitHub.Shared.Models
{
    public class TransitCenter: ITransitStop
    {
        public Point location;

        public TransitCenter(double lat, double lng)
        {
            location = new Point(lat, lng);
        }

        public Point GetLocation()
        {
            return location;
        }
    }
}
