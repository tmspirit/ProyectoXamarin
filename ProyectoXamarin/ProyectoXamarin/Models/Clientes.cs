using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class Clientes
    {
        [JsonProperty("codigoCliente")]
        public int CodigoCliente { get; set; }
        [JsonProperty("nombre")]
        public String Nombre { get; set; }
        [JsonProperty("contacto")]
        public String Contacto { get; set; }
        [JsonProperty("passwd")]
        public String Password { get; set; }
        [JsonProperty("ciudad")]
        public String Ciudad { get; set; }
        [JsonProperty("telefono")]
        public double Telefono { get; set; }
        [JsonProperty("imagen_Cliente")]
        public string Imagen_Cliente { get; set; }
        [JsonProperty("rol")]
        public String Rol { get; set; }
        [JsonProperty("salt")]
        public String Salt { get; set; }
        [JsonProperty("iteraciones")]
        public int Iteraciones { get; set; }


    }
}
