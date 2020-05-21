using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class Carrito
    {
        public ObservableCollection<int> Productos { get; set; }
        public int precio { get; set; }

        public Carrito() {
            this.Productos = new ObservableCollection<int>();
        }
    }
}
