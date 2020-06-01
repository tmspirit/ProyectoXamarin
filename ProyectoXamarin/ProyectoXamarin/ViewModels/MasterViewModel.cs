using ProyectoXamarin.Base;
using ProyectoXamarin.Code;
using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using ProyectoXamarin.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class MasterViewModel : ViewModelBase  
    {
        RepositoryMotores repo;
        public MasterViewModel(RepositoryMotores repo)
        {
            this.repo = repo;
            this.MasterItems = new ObservableCollection<MasterPageItem>();
            this.Cliente = new Clientes();
            string tok = string.Empty;

            //Motores
            MasterPageItem motoresmenu = new MasterPageItem();
            motoresmenu.Imagen = "productos.png";
            motoresmenu.Titulo = "Productos";
            motoresmenu.Pagina = typeof(ProductosView);
            MasterItems.Add(motoresmenu);

            //Carrito
            MasterPageItem carrito = new MasterPageItem();
            carrito.Imagen = "cart.png";
            carrito.Titulo = "Carrito";
            carrito.Pagina = typeof(CarritoView);
            MasterItems.Add(carrito);

            

            //Login
            if (!Application.Current.Properties.ContainsKey("Token"))
            {
                MasterPageItem login = new MasterPageItem();
                login.Imagen = "login.png";
                login.Titulo = "Login";
                login.Pagina = typeof(Login);
                MasterItems.Add(login);
            }
            else
            {
                tok = Application.Current.Properties["Token"].ToString();
                Task.Run(async () => {
                    Clientes cliente = await miCliente();
                    MasterPageItem perfil = new MasterPageItem();
                    perfil.Imagen = "perfil.png";
                    perfil.Titulo = cliente.Nombre;
                    MasterItems.Add(perfil);
                });
               
            }

            //LogOut
            if (Application.Current.Properties.ContainsKey("Token"))
            {
                if (Application.Current.Properties["Token"].ToString() != String.Empty)
                {
                    MasterPageItem logout = new MasterPageItem();
                    logout.Imagen = "logout.png";
                    logout.Titulo = "Cerrar sesion";
                    MasterItems.Add(logout);
                    //MisPedidos
                    MasterPageItem mispedidos = new MasterPageItem();
                    mispedidos.Imagen = "delivery.png";
                    mispedidos.Titulo = "Mis Pedidos";
                    mispedidos.Pagina = typeof(MisPedidosView);
                    MasterItems.Add(mispedidos);
                }
                else
                {
                    MasterPageItem login = new MasterPageItem();
                    login.Imagen = "login.png";
                    login.Titulo = "Login";
                    login.Pagina = typeof(Login);
                    MasterItems.Add(login);
                }
            }
        }

        public async Task<Clientes> miCliente()
        {
            string token = Application.Current.Properties["Token"].ToString();
            Clientes cliente = await repo.GetPerfil(token);
            return cliente;
        }

        private ObservableCollection<MasterPageItem> _MasterItems;
        public ObservableCollection<MasterPageItem> MasterItems
        {
            get { return this._MasterItems; }
            set
            {
                this._MasterItems = value;
                OnPropertyChanged("MasterItems");
            }
        }

        private Clientes _Cliente;
        public Clientes Cliente
        {
            get { return this._Cliente; }
            set
            {
                this._Cliente = value;
                OnPropertyChanged("Cliente");
            }
        }
    }
}
