using Mapsui;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransitHub.Shared.Interfaces
{
    public interface IMapFactory
    {
        Map CreateMap(ITransitHub hub);
        Map CreateMap(ITransitLocation stop);
    }
}
