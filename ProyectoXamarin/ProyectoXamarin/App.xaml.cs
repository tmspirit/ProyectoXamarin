using ProyectoXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProductosView());
            //MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            Application.Current.Properties.Add("Token", "");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
