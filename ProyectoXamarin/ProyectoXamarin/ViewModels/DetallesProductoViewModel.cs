using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using ProyectoXamarin.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class DetallesProductoViewModel : ViewModelBase
    {
        RepositoryMotores repo;
        public DetallesProductoViewModel()
        {
            this.repo = new RepositoryMotores();
            Task.Run(async () => await GetProductoAsync());
        }

        private Productos _Producto;
        public Productos Producto
        {
            get { return this._Producto; }
            set
            {
                this._Producto = value;
                OnPropertyChanged("Producto");
            }
        }

        private int _motorId;
        public int MotorID
        {
            get { return _motorId; }
            set { _motorId = value; OnPropertyChanged("MotorID"); }
        }

        private ObservableCollection<Productos> _productos;
        public ObservableCollection<Productos> Productos
        {
            get { return _productos; }
            set { _productos = value; OnPropertyChanged("Productos"); }
        }

        public async Task<ObservableCollection<Productos>> GetProductoAsync()
        {
            ObservableCollection<Productos> productos = new ObservableCollection<Productos>();
            Productos produ = await repo.GetProducto(MotorID);
            productos.Add(produ);
            return productos;
        }

       
        private string _Comentario;
        public string Comentario
        {
            get { return this._Comentario; }
            set { this._Comentario = value; OnPropertyChanged("Comentario"); }
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
                    Application.Current.Properties["Carrito"] = carrito;
                    MessagingCenter.Send(App.Locator.CarritoViewModel, "REFRESH");
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
                            await Application.Current.MainPage.Navigation.PushModalAsync(view);
                        }
                        else await Application.Current.MainPage.DisplayAlert("Lo sentimos", "No hay comentarios disponibles para ese producto", "Volver");
                    }
                    else await Application.Current.MainPage.Navigation.PushModalAsync(new Login());
                    //else App.Locator.MainMotoresView.Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Login)));
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
                        string texto = Comentario;
                        int masterIdCommment = 0;
                        if (texto != null)
                        {
                            await repo.SetComentario(productoId, texto, masterIdCommment, token);
                            Comentario comentario = new Comentario();
                            comentario.Comment = string.Empty;
                            Comentario = comentario.Comment; 
                        }
                        else await Application.Current.MainPage.DisplayAlert("Error", "Por favor escriba un comentario para postear", "Cancel");
                    }
                    else await Application.Current.MainPage.Navigation.PushModalAsync(new Login());
                });
            }
        }
    }
}
