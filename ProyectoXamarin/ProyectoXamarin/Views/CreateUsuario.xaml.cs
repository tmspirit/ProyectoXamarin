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
    public partial class CreateUsuario : ContentPage
    {
        RepositoryMotores repo;
        public CreateUsuario()
        {
            InitializeComponent();
            this.repo = new RepositoryMotores();
            this.bntCreate.Clicked += BntCreate_Clicked;
        }

        private async void BntCreate_Clicked(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.Nombre = this.entryNombre.Text;
            cliente.Contacto = this.entryCiudad.Text;
            cliente.Ciudad = this.entryCiudad.Text;
            cliente.Telefono = Double.Parse(this.entryTelefono.Text) ;
            cliente.Password = this.entryPass.Text;

            await repo.RegistrarCliente(cliente);
            throw new NotImplementedException();
        }
    }
}