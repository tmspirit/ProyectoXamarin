using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using ProyectoXamarin.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallesProductoView : ContentPage
    {
        RepositoryMotores repo;
        public DetallesProductoView(int motorId)
        {
            InitializeComponent();
            this.repo = new RepositoryMotores();
            Task.Run(() => GetProductoAsync(motorId));
        }

        public async Task GetProductoAsync(int motorId)
        {
            ObservableCollection<Productos> productos = new ObservableCollection<Productos>();
            Productos produ = await repo.GetProducto(motorId);
            productos.Add(produ);
            lsvProducto.ItemsSource = productos;
        }
        protected override async void OnAppearing()
        {
            DetallesProductoViewModel viewModel = (DetallesProductoViewModel)this.BindingContext;
            viewModel.Productos = await viewModel.GetProductoAsync();
        }
    }
}