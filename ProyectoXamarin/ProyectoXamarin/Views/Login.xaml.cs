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

            String token = await repo.GetToken(entryUsuario.Text, entryPass.Text);
            //String token = await repo.GetToken("user", "user");
            //String token = await repo.GetToken("dionisio@dionisio.6", "erdioniguay");
            //Usuario/Pass OK
            if (token != null)
            {
                //Guardo token
                Application.Current.Properties["Token"] = token;


                //SIRVE PARA COMPROBAR SI LA PAGINA SE ESTA EJECUTANDO COMO MODAL
                //EN CASO DE QUE SEA MODAL CIERRO EL MODAL PARA QUE VUELVA A DETALLES DEL PRODUCTO
                //SIN QUE TENGAS QUE PASAR POR PRODUCTOS OTRA VEZ
                IReadOnlyList<Page> page = Navigation.NavigationStack;
                bool res = page.Contains<Page>(this);
                if (res == false) {
                    await Navigation.PopModalAsync();
                }
                else
                {
                    //ME PARECE MAS PRACTICO ESTO PARA EVITAR SECUENCIAS INFINITAS DE MODALES
                    //await Application.Current.MainPage.DisplayAlert("ATENCION", "Ha iniciado sesion", "Volver");
                }

                //Redirijo a Productos
                //Navigation.PushAsync(new ProductosView());

                //await Navigation.PushModalAsync(new ProductosView());
                Application.Current.MainPage = new MainMotoresView();
            }
            else
            {
                //Mensaje pass Incorrecta

            }     
        }
    }
}