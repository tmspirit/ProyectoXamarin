using ProyectoXamarin.Code;
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
        public MainMotoresView()
        {
            InitializeComponent();
            List<MasterPageItem> menu = new List<MasterPageItem>();
            //Motores
            MasterPageItem motoresmenu =
                new MasterPageItem();
            motoresmenu.Imagen = "hospital.png";
            motoresmenu.Titulo = "Productos";
            motoresmenu.Pagina = typeof(ProductosView);
            menu.Add(motoresmenu);
            //Login
            MasterPageItem login = new MasterPageItem();
            login.Imagen = "";
            login.Titulo = "Login";
            login.Pagina = typeof(Login);
            menu.Add(login);
            //Carrito
            MasterPageItem carrito = new MasterPageItem();
            carrito.Imagen = "";
            carrito.Titulo = "Carrito";
            carrito.Pagina = typeof(CarritoView);
            menu.Add(carrito);
            this.lsvmenu.ItemsSource = menu;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ProductosView)));
        }

        private void lsvmenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MasterPageItem itemselected = e.SelectedItem as MasterPageItem;
            Type page = itemselected.Pagina;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
        }
    }
}