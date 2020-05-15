using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class Oferta
    {
        [JsonProperty("idoferta")]
        public int IdOferta { get; set; }
        [JsonProperty("idproducto")]
        public int IdProducto { get; set; }
        [JsonProperty("fechainicio")]
        public DateTime FechaInicio { get; set; }
        [JsonProperty("fechafinal")]
        public DateTime FechaFinal { get; set; }
        [JsonProperty("descuento")]
        public int Descuento { get; set; }
    }
}
