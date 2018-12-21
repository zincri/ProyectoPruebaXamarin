namespace ProyectoPrueba.Models
{
    using System;
    using Newtonsoft.Json;
    public class User
    {
        [JsonProperty(PropertyName = "codigo")]
        public int Codigo { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public String Nombre { get; set; }

        [JsonProperty(PropertyName = "edad")]
        public int Edad { get; set; }

        [JsonProperty(PropertyName = "correo")]
        public String Correo { get; set; }

        [JsonProperty(PropertyName = "pas")]
        public String Pas { get; set; }
    }
}
