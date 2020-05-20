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
    public partial class ComentariosView : ContentPage
    {
        RepositoryMotores repo;
        Task TaskComentarios;
        public ComentariosView(int productoId)
        {
            InitializeComponent();
            this.repo = new RepositoryMotores();
            TaskComentarios = GetComentariosAsync(productoId);
        }

        public async Task GetComentariosAsync(int productoId)
        {
            string token = Application.Current.Properties["Token"].ToString();
            if (token != "")
            {
                List<Comentario> comentarios = await repo.GetComentarios(productoId);
                foreach (Comentario c in comentarios)
                {
                    Clientes cliente = await repo.FindCliente(c.IdCliente,  token);
                    c.Clientes = cliente;

                    lblNombre.Text = c.Clientes.Nombre;
                    lblComentario.Text = c.Comment;
                    imgImgenCliente.Source = c.Clientes.Imagen_Cliente;
                }
            }
            else await Navigation.PushAsync(new Login());
        }
    }
}