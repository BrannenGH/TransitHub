using Mapsui.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransitHub.Shared.Models.Interfaces
{
    interface ITransitVehicle
    {
        Point Location { get; }
    }
}
