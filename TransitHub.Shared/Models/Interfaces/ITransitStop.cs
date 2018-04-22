using Mapsui.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransitHub.Shared.Interfaces
{
    public interface ITransitStop
    {
        Point GetLocation();
    }
}
