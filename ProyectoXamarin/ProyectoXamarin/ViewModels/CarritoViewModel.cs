using ProyectoXamarin.Models;
using System;
using ProyectoXamarin.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using ProyectoXamarin.Helpers;

namespace ProyectoXamarin.ViewModels
{
    public class CarritoViewModel
    {
        private RepositoryMotores repo;
        private Carrito _Carrito;
        public Carrito Carrito {
            get { return this._Carrito; }
            set {
                this._Carrito.Productos = new ObservableCollection<int>();
                this._Carrito = GenerarCarrito();
            }
        }

        private NotifyTaskCompletion<ObservableCollection<Productos>> _TareaProductos;

        public NotifyTaskCompletion<ObservableCollection<Productos>> TareaProductos {
            get { return this._TareaProductos; }
            set { 
                this._TareaProductos = value;
            }
        }

        public CarritoViewModel() {
            this.repo = new RepositoryMotores();
            this._Carrito = GenerarCarrito();

            this._TareaProductos = 
                new NotifyTaskCompletion<ObservableCollection<Productos>>(CargarProductos(this._Carrito.Productos));
            MessagingCenter.Subscribe<CarritoViewModel>
                (this, "REFRESH", (sender) => {
                    Carrito carrito = GenerarCarrito();
                    this.TareaProductos = 
                    new NotifyTaskCompletion<ObservableCollection<Productos>>(CargarProductos(carrito.Productos));
                });
        }

        public async Task<ObservableCollection<Productos>> CargarProductos(ObservableCollection<int> carrito){
            ObservableCollection<Productos> productos = new ObservableCollection<Productos>();
            foreach (int id_motor in carrito) {
                Productos producto = await this.repo.GetProducto(id_motor);
                productos.Add(producto);
            }
            return productos;
        }

        private Carrito GenerarCarrito()
        {
            Carrito carrito = new Carrito();
            if (Application.Current.Properties["Carrito"] != null)
            {
                carrito.Productos = (ObservableCollection<int>)Application.Current.Properties["Carrito"];
            }
            return carrito;
        }
    }
}
