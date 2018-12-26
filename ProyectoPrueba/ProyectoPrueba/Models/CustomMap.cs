namespace ProyectoPrueba.Models
{
    using System.Collections.Generic;
    using Xamarin.Forms.Maps;
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
    }
}
