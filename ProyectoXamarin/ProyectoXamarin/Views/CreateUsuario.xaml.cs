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
            this.bntBack.Clicked += BntBack_Clicked;
        }

        private async void BntBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async void BntCreate_Clicked(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.Nombre = this.entryNombre.Text;
            cliente.Contacto = this.entryContacto.Text;
            cliente.Ciudad = this.entryCiudad.Text;
            cliente.Telefono = Double.Parse(this.entryTelefono.Text) ;
            cliente.Password = this.entryPass.Text;

            int res= await repo.RegistrarCliente(cliente);
            if (res == 0) {
                String token = await repo.GetToken(cliente.Nombre, this.entryPass.Text);
                Application.Current.Properties["Token"] = token;
                await Navigation.PushAsync(new ProductosView());
            }
            else
            {
                //error
            }
        }
    }
}