using ProyectoXamarin.Code;
using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMotoresView : MasterDetailPage
    {
        RepositoryMotores repo = new RepositoryMotores();
        public MainMotoresView()
        {
            InitializeComponent();

            List<MasterPageItem> menu = new List<MasterPageItem>();

            ////Perfil
            //if (Application.Current.Properties.ContainsKey("Token"))
            //{
            //    if (Application.Current.Properties["Token"].ToString() != String.Empty)
            //    {
            //        String tok = Application.Current.Properties["Token"].ToString();
            //        Clientes cliente = null;

            //        Task.Run(async () => {
            //            cliente = await repo.GetPerfil(tok);
            //        });
            //        String nombreCli = cliente.Nombre.ToString();

            //        MasterPageItem perfil = new MasterPageItem();
            //        perfil.Imagen = "";
            //        perfil.Titulo = nombreCli;
            //        //login.Pagina = typeof(Login);
            //        menu.Add(perfil);
            //    }
            //}

            //Motores
            MasterPageItem motoresmenu =
                new MasterPageItem();
            motoresmenu.Imagen = "hospital.png";
            motoresmenu.Titulo = "Productos";
            motoresmenu.Pagina = typeof(ProductosView);
            menu.Add(motoresmenu);
          
            //Carrito
            MasterPageItem carrito = new MasterPageItem();
            carrito.Imagen = "";
            carrito.Titulo = "Carrito";
            carrito.Pagina = typeof(CarritoView);
            menu.Add(carrito);
            this.lsvmenu.ItemsSource = menu;

            //Login
            if (!Application.Current.Properties.ContainsKey("Token"))
            {
                MasterPageItem login = new MasterPageItem();
                login.Imagen = "";
                login.Titulo = "Login";
                login.Pagina = typeof(Login);
                menu.Add(login);
            }
            else
            {

                String tok = Application.Current.Properties["Token"].ToString();
                Clientes cliente = null;

                Task.Run(async () =>
                {
                    cliente = await repo.GetPerfil(tok);
                });
                String nombreCli = cliente.Nombre.ToString();

                MasterPageItem perfil = new MasterPageItem();
                perfil.Imagen = "";
                perfil.Titulo = nombreCli;
                //login.Pagina = typeof(Login);
                menu.Add(perfil);
            }

            //LogOut

            if (Application.Current.Properties.ContainsKey("Token") )
            {
                if (Application.Current.Properties["Token"].ToString() != String.Empty)
                {
                    //Application.Current.Properties.Remove("Name");
                    MasterPageItem logout = new MasterPageItem();
                    logout.Imagen = "";
                    logout.Titulo = "Cerrar sesion";
                    menu.Add(logout);
                    this.lsvmenu.ItemsSource = menu;
                }
                else
                {
                    MasterPageItem login = new MasterPageItem();
                    login.Imagen = "";
                    login.Titulo = "Login";
                    login.Pagina = typeof(Login);
                    menu.Add(login);
                }
            }
                
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ProductosView)));
        }

        private void lsvmenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MasterPageItem itemselected = e.SelectedItem as MasterPageItem;
            Type page = itemselected.Pagina;
            String tit = itemselected.Titulo;
            if(tit!= "Login" && tit != "Carrito" && tit != "Productos")
            {
                LogOut();
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            }
            
            IsPresented = false;
        }
        public async void LogOut() {
            Application.Current.Properties.Remove("Token");
            Application.Current.MainPage = new MainMotoresView();
            await Application.Current.MainPage.DisplayAlert("Sesion Finalizada", "Hasta pronto", "OK");          
        }
    }
}