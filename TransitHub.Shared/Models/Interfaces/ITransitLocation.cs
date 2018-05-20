using Mapsui.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransitHub.Shared.Interfaces
{
    /// <summary>
    /// Defines a location on a map that can be navigated to.
    /// </summary>
    public interface ITransitLocation
    {
        /// <summary>
        /// The center location of the map point.
        /// </summary>
        Point Location { get; }
    }
}
