﻿namespace ProyectoPrueba.Views
{
    using System.Collections.Generic;
    using ProyectoPrueba.Models;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();
            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(37.79752, -122.40183),
                Label = "Xamarin San Francisco Office",
                Address = "394 Pacific Ave, San Francisco CA",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
            };

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));


        }
    }
}
