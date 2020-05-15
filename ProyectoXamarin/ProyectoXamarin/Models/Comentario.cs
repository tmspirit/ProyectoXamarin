using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class Comentario
    {
        [JsonProperty("idcomentario")]
        public int IdComentario { get; set; }
        [JsonProperty("idcliente")]
        public int IdCliente { get; set; }
        [JsonProperty("idproducto")]
        public int IdProducto { get; set; }
        [JsonProperty("comment")]
        public String Comment { get; set; }
        [JsonProperty("fechacomentario")]
        public DateTime FechaComentario { get; set; }
        [JsonProperty("idmastercomment")]
        public int IdMasterComment;
    }
}
