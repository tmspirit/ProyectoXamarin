using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class Pedidos
    {
        [JsonProperty("id_pedido")]
        public int Id_pedido { get; set; }
        [JsonProperty("id_cliente")]
        public int Id_cliente { get; set; }
        [JsonProperty("ids_productos")]
        public String Ids_productos { get; set; }
        [JsonProperty("numproductos")]
        public int Numproductos { get; set; }
        [JsonProperty("preciopedido")]
        public int Preciopedido { get; set; }
        [JsonProperty("fechasalida")]
        public DateTime Fechasalida { get; set; }
        [JsonProperty("fechallegada")]
        public DateTime Fechallegada { get; set; }
        [JsonProperty("direccionenvio")]
        public String DireccionEnvio { get; set; }
    }
}
