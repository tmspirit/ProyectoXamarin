using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using ProyectoXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class DetallesProductoViewModel : ViewModelBase
    {
        RepositoryMotores repo;
        private Productos _Producto;
        public Productos Producto {
            get { return this._Producto; }
            set
            {
                this._Producto = value;
                OnPropertyChanged("Producto");
            }
        }
        private Comentario _Comentario;
        public Comentario Comentario {
            get { return this._Comentario; }
            set {
                this._Comentario = value;
                OnPropertyChanged("Comentario");
            }
        }
        public DetallesProductoViewModel() {
            this.repo = new RepositoryMotores();
            Comentario = new Comentario();
        }

        public Command AñadirAlCarrito {
            get {
                return new Command(() =>
                {
                    ObservableCollection<int> carrito;
                    if (Application.Current.Properties["Carrito"] != null)
                    {
                        carrito = (ObservableCollection<int>)Application.Current.Properties["Carrito"];
                    }
                    else
                    {
                        carrito = new ObservableCollection<int>();
                    }
                    carrito.Add(Producto.Id_motor);
                });
            }
        }

        public Command VerComentarios
        {
            get
            {
                return new Command(async ()=> {
                    string token = Application.Current.Properties["Token"].ToString();
                    if (token != "")
                    {
                        int productoId = Producto.Id_motor;
                        if (productoId != 0)
                        {
                            ComentariosViewModel viewmodel = App.Locator.ComentariosViewModel;
                            viewmodel.ProductoID = productoId;
                            ComentariosView view = new ComentariosView();
                            view.BindingContext = viewmodel;
                            await Application.Current.MainPage.Navigation.PushAsync(view);
                        }
                        //else await DisplayAlert("Lo sentimos", "No hay comentarios disponibles para ese producto", "Volver");
                    }
                    else await Application.Current.MainPage.Navigation.PushAsync(new Login());
                });
            }
        }

        public Command PostComentario {
            get
            {
                return new Command(async() =>
                {
                    string token = Application.Current.Properties["Token"].ToString();
                    if (token != "")
                    {
                        int productoId = Producto.Id_motor;
                        string texto = Comentario.Comment;
                        int masterIdCommment = 0;
                        if (texto != null)
                        {
                            await repo.SetComentario(productoId, texto, masterIdCommment, token);
                            Comentario comentario = new Comentario();
                            comentario.Comment = string.Empty;
                            Comentario = comentario; 
                        }
                        //else await DisplayAlert("Error", "Por favor escriba un comentario para postear", "Cancel");
                    }
                    else await Application.Current.MainPage.Navigation.PushAsync(new Login());
                });
            }
        }

        
    }
}
