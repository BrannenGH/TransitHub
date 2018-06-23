using Mapsui;
using Mapsui.UI.Uwp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransitHub.Shared.Interfaces;
using TransitHub.Shared.Models;

namespace TransitHub.ViewModels
{
    class MapViewModel
    {
        public Map Map { private get; set; }
        private MapControl _mapControl;
        private MapFactory mapFactory;

        public MapControl MapControl
        {
            get
            {
                if (_mapControl == null)
                {
                    _mapControl = new MapControl();
                }
                _mapControl.Map = Map;
                return _mapControl;
            }
        }

        public MapViewModel()
        {
            mapFactory = new MapFactory();
            InitializeMap();
        }

        public bool InitializeMap()
        {
            try
            {
                var northtownStops = new List<ITransitStop>
                {
                    new TransitStop(-93.264399, 45.126965)
                };
                ITransitHub northtown =
                    new TransitCenter(-93.264399, 45.126965, northtownStops);
                Map = mapFactory.CreateMap(northtown);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
