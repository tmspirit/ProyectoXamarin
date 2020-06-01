using ProyectoXamarin.Base;
using ProyectoXamarin.Code;
using ProyectoXamarin.Helpers;
using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using ProyectoXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class MasterViewModel : ViewModelBase  
    {
        RepositoryMotores repo;
        private ObservableCollection<MasterPageItem> _MasterItems;
        public ObservableCollection<MasterPageItem> MasterItems
        {
            get { return this._MasterItems; }
            set
            {
                this._MasterItems = value;
                OnPropertyChanged("MasterItems");
            }
        }

        private Clientes _Cliente;
        public Clientes Cliente
        {
            get { return this._Cliente; }
            set
            {
                this._Cliente = value;
                OnPropertyChanged("Cliente");
            }
        }

        public MasterViewModel()
        {
            this.repo = new RepositoryMotores();
            this.MasterItems = new ObservableCollection<MasterPageItem>();
            this.Cliente = new Clientes();
            String tok = "";
            Clientes cliente = new Clientes();
            if (Application.Current.Properties.ContainsKey("Token"))
            {
                if (Application.Current.Properties["Token"].ToString() != String.Empty)
                {

                    tok = Application.Current.Properties["Token"].ToString();
                    NotifyTaskCompletion<Clientes> taskcli = new NotifyTaskCompletion<Clientes>(this.repo.GetPerfil(tok));
                    this.Cliente = taskcli.Result;

                    MasterPageItem perfil = new MasterPageItem();
                    perfil.Imagen = "";
                    //perfil.Titulo = nombreCli;
                    perfil.Titulo = this.Cliente.Nombre;
                    //login.Pagina = typeof(Login);
                    MasterItems.Add(perfil);
                }
            }


            //Motores
            MasterPageItem motoresmenu =
                new MasterPageItem();
            motoresmenu.Imagen = "hospital.png";
            motoresmenu.Titulo = "Productos";
            motoresmenu.Pagina = typeof(ProductosView);
            MasterItems.Add(motoresmenu);

            //Carrito
            MasterPageItem carrito = new MasterPageItem();
            carrito.Imagen = "";
            carrito.Titulo = "Carrito";
            carrito.Pagina = typeof(CarritoView);
            MasterItems.Add(carrito);

            //Login
            if (!Application.Current.Properties.ContainsKey("Token"))
            {
                MasterPageItem login = new MasterPageItem();
                login.Imagen = "";
                login.Titulo = "Login";
                login.Pagina = typeof(Login);
                MasterItems.Add(login);
            }
            else
            {
                tok = Application.Current.Properties["Token"].ToString();
                NotifyTaskCompletion<Clientes> taskcli = new NotifyTaskCompletion<Clientes>(this.repo.GetPerfil(tok));
                this.Cliente = taskcli.Result;
                //tok = Application.Current.Properties["Token"].ToString();

                //Task.Run(async () =>
                //{
                //    cliente = await repo.GetPerfil(tok);
                //});
                //nombreCli = cliente.Nombre.ToString();

                MasterPageItem perfil = new MasterPageItem();
                perfil.Imagen = "";
                perfil.Titulo = this.Cliente.Nombre;
                //login.Pagina = typeof(Login);
                MasterItems.Add(perfil);
            }


            //LogOut


            if (Application.Current.Properties.ContainsKey("Token"))
            {
                if (Application.Current.Properties["Token"].ToString() != String.Empty)
                {
                    //Application.Current.Properties.Remove("Name");
                    MasterPageItem logout = new MasterPageItem();
                    logout.Imagen = "";
                    logout.Titulo = "Cerrar sesion";
                    MasterItems.Add(logout);
                }
                else
                {
                    MasterPageItem login = new MasterPageItem();
                    login.Imagen = "";
                    login.Titulo = "Login";
                    login.Pagina = typeof(Login);
                    MasterItems.Add(login);
                }
            }
        }
    }
}
