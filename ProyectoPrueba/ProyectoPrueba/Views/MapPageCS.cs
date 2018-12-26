namespace ProyectoPrueba.Views
{
    using System.Collections.Generic;
    using ProyectoPrueba.Models;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;

    public class MapPageCS : ContentPage
    {
        public MapPageCS()
        {
            var customMap = new CustomMap
            {
                MapType = MapType.Street,
                WidthRequest = App.ScreenWidth,
                HeightRequest = App.ScreenHeight
            };

            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(16.7459503, -93.2696561),
                Label = "Tuxtla Gutiérrez",
                Address = "Chiapas",
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"

            };

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(16.7459503, -93.2696561), Distance.FromMiles(1.0)));

            Content = customMap;
        }
    }
}
