using Mapsui.Layers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransitHub.Shared.Interfaces
{
    public interface ITransitHub: ITransitLocation
    {
        IEnumerable<ITransitStop> Stops { get; }

        MemoryLayer CreateStopLayer();
    }
}
