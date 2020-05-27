using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        RepositoryMotores repo;
        public Login()
        {
            InitializeComponent();
            this.repo = new RepositoryMotores();
            this.bntLogin.Clicked += BntLogin_Clicked;
            this.bntContinuar.Clicked += BntContinuar_Clicked;
            this.btnRegistrarse.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(() => {
                        Navigation.PushAsync(new CreateUsuario());
                    })
                }
            );
        }
        private void BntContinuar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductosView());
        }

        private async void BntLogin_Clicked(object sender, EventArgs e)
        {
            //        CLIENTE:
            //        EMAIL: dionisio@dionisio.6
            //        PASSWORD: erdioniguay / o si no dionisio

            //String token = await repo.GetToken(entryUsuario.Text, entryPass.Text);
            String token = await repo.GetToken("user", "user");
            //String token = await repo.GetToken("dionisio@dionisio.6", "erdioniguay");
            //Usuario/Pass OK
            if (token != null)
            {
                //Guardo token
                Application.Current.Properties["Token"] = token;
                //Redirijo a Productos
                //Navigation.PushAsync(new ProductosView());
                //NO TE ASUSTES ANTHONY ESQUE NECESITO INICIALIZAR EL CARRITO EN ALGUN LAO
                //Y ESTE ME PARECIA EL SITIO MAS ADECUADO
                Application.Current.Properties["Carrito"] = null;
                await Navigation.PushAsync(new ProductosView());
            }
            else
            {
                //Mensaje pass Incorrecta

            }     
        }
    }
}