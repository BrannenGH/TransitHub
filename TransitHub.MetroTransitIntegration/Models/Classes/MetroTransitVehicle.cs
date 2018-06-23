using Mapsui.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransitHub.MetroTransitIntegration.Models
{
    public class MetroTransitVehicle
    {
        [JsonProperty(PropertyName = "Bearing")]
        public int Bearing { get; private set; }

        [JsonProperty(PropertyName = "BlockNumber")]
        public int BlockNumber { get; private set; }

        [JsonProperty(PropertyName = "Direction")]
        public int Direction { get; private set; }

        [JsonProperty(PropertyName = "LocationTime")]
        public string LocationTime { get; private set; }

        [JsonProperty(PropertyName = "VehicleLatitude")]
        private double _latitude;

        [JsonProperty(PropertyName = "VehicleLongitude")]
        private double _longitude;

        public Point Location
        {
            get
            {
                return new Point(_longitude, _latitude);
            }
        }
    }
}
