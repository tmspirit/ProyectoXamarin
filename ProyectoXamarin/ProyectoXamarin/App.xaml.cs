using ProyectoXamarin.Services;
using ProyectoXamarin.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ProyectoXamarin
{
    public partial class App : Application
    {
        private static ServiceDependency _locator;
        public static ServiceDependency Locator
        {
            get { return _locator = _locator ?? new ServiceDependency(); }
        }
        public App()
        {
            InitializeComponent();
            Application.Current.Properties["Carrito"] = new ObservableCollection<int>();
            MainPage = new MainMotoresView();

        }

        protected override void OnStart()
        {
            Application.Current.Properties["Token"] = String.Empty;
            Application.Current.Properties["Carrito"] = new ObservableCollection<int>();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
