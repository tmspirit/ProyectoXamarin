using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallesProductoView : ContentPage
    {
        RepositoryProductos repo;
        private Task TaskProducto;
        public DetallesProductoView(int motorId)
        {
            InitializeComponent();
            this.repo = new RepositoryProductos();
            TaskProducto = GetProductoAsync(motorId);
            btnVerComentarios.Clicked += BtnVerComentarios_Clicked;
            btnPostComentario.Clicked += BtnPostComentario_Clicked;
        }

        private void BtnPostComentario_Clicked(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BtnVerComentarios_Clicked(object sender, EventArgs e)
        {
            int productoId = lsvProducto.ItemsSource.Cast<Productos>().Select(x => x.Id_motor).FirstOrDefault();
            if (productoId != 0) Navigation.PushAsync(new ComentariosView());
            else DisplayAlert("Lo sentimos", "No hay comentarios disponibles para ese producto", "Volver");
        }

        public async Task GetProductoAsync(int motorId)
        {
            ObservableCollection<Productos> productos = new ObservableCollection<Productos>();
            Productos produ = await repo.GetProducto(motorId);
            productos.Add(produ);
            lsvProducto.ItemsSource = productos;
        }
    }
}