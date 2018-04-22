using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Mapsui;
using TransitHub.Shared.Interfaces;
using TransitHub.Shared.Models;

namespace TransitHub
{
    public sealed partial class MainPage : Page
    {
        private IMapFactory mapFactory;
        public Map map;

        public MainPage()
        {
            this.InitializeComponent();
            mapFactory = new MapFactory();

            //Testing code, to be loaded from Azure
            //var _northtown = new TransitCenter(45.126965, -93.264399);
            var _northtown = new TransitCenter(45.126965, -93.264399);

            map = mapFactory.CreateMap(_northtown);
            MapControl.Map = map;
        }
    }
}
