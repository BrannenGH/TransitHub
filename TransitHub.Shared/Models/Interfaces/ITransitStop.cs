using Mapsui.Geometries;
using Mapsui.Providers;
using Mapsui.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransitHub.Shared.Interfaces
{
    /// <summary>
    /// Defines a single transit stop.
    /// </summary>
    public interface ITransitStop: ITransitLocation
    {
        /// <summary>
        /// The feature that represents the location
        /// and information about the stop.
        /// </summary>
        IFeature Feature { get; }

        /// <summary>
        /// The current icon for the stop.
        /// </summary>
        SymbolStyle Icon { get; }
    }
}
