using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class Productos
    {
        [JsonProperty("id_motor")]
        public int Id_motor { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("imagen")]
        public String Imagen { get; set; }
        [JsonProperty("precio")]
        public int Precio { get; set; }
        [JsonProperty("potencia")]
        public int Potencia { get; set; }
        [JsonProperty("max_par")]
        public int Max_par { get; set; }
        [JsonProperty("consumo")]
        public int Consumo { get; set; }
        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }
        [JsonProperty("stock")]
        public int Stock { get; set; }
    }
}
