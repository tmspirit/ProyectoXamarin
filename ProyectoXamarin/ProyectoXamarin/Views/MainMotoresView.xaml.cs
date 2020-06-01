using ProyectoXamarin.Code;
using ProyectoXamarin.Repositories;
using System;


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
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ProductosView)));
        }


        private void lsvmenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MasterPageItem itemselected = e.SelectedItem as MasterPageItem;
            Type page = itemselected.Pagina;
            String tit = itemselected.Titulo;
            if (tit != "Login" && tit != "Carrito" && tit != "Productos")
            {
                LogOut();
            }
            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            }

            IsPresented = false;
        }
        public async void LogOut()
        {
            Application.Current.Properties.Remove("Token");
            Application.Current.MainPage = new MainMotoresView();
            await Application.Current.MainPage.DisplayAlert("Sesion Finalizada", "Hasta pronto", "OK");
        }
    }
}