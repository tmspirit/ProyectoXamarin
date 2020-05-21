using ProyectoXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class CarritoViewModel
    {
        private Carrito _Carrito;
        public Carrito Carrito { 
            get { return this._Carrito; }
            set {
                this._Carrito.Productos = new ObservableCollection<int>();
                this._Carrito = GenerarCarrito();
            }
        }

        public CarritoViewModel() {
            this._Carrito = GenerarCarrito();
        }

        private Carrito GenerarCarrito()
        {
            Carrito carrito = new Carrito();
            carrito.Productos.Add(1);
            carrito.Productos.Add(2);
            carrito.Productos.Add(3);
            carrito.Productos.Add(4);
            return carrito;
        }
    }
}
