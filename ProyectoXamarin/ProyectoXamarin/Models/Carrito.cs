using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class Carrito
    {
        public List<int> productos { get; set; }
        public int precio { get; set; }
    }
}
