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
        RepositoryMotores repo;
        private Task TaskProducto;
        public DetallesProductoView(int motorId)
        {
            InitializeComponent();
            this.repo = new RepositoryMotores();
            TaskProducto = GetProductoAsync(motorId);
            btnVerComentarios.Clicked += BtnVerComentarios_Clicked;
            btnPostComentario.Clicked += BtnPostComentario_Clicked;
        }

        private async void BtnPostComentario_Clicked(object sender, EventArgs e)
        {
            string token = Application.Current.Properties["Token"].ToString();
            if (token != "")
            {
                int productoId = lsvProducto.ItemsSource.Cast<Productos>().Select(x => x.Id_motor).FirstOrDefault();
                string texto = txtComentario.Text;
                int masterIdCommment = 0;
                if (texto != null)
                {
                    await repo.SetComentario(productoId, texto, masterIdCommment, token);
                    txtComentario.Text = string.Empty;
                }
                else await DisplayAlert("Error", "Por favor escriba un comentario para postear", "Cancel");
            }
            else await Navigation.PushAsync(new Login());
            
        }

        private async void BtnVerComentarios_Clicked(object sender, EventArgs e)
        {
            string token = Application.Current.Properties["Token"].ToString();
            if (token != "")
            {
                int productoId = lsvProducto.ItemsSource.Cast<Productos>().Select(x => x.Id_motor).FirstOrDefault();
                if (productoId != 0) await Navigation.PushModalAsync(new ComentariosView(productoId));
                else await DisplayAlert("Lo sentimos", "No hay comentarios disponibles para ese producto", "Volver");
            }
            else await Navigation.PushAsync(new Login());
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