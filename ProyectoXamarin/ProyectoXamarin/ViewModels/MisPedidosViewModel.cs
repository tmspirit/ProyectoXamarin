using ProyectoXamarin.Base;
using ProyectoXamarin.Helpers;
using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class MisPedidosViewModel: ViewModelBase
    {
        RepositoryMotores repo;
        private NotifyTaskCompletion<ObservableCollection<Pedidos>> _Pedidos;
        public NotifyTaskCompletion<ObservableCollection<Pedidos>> Pedidos
        {
            get { return this._Pedidos; }
            set {
                this._Pedidos = value;
                OnPropertyChanged("Pedidos");   
            }
        }

        public MisPedidosViewModel(){
            this.repo = new RepositoryMotores();
            CargarPedidos();
        }
        

        public void CargarPedidos()
        {
            String token = Application.Current.Properties["Token"].ToString();
            this.Pedidos = new NotifyTaskCompletion<ObservableCollection<Pedidos>>(this.repo.VerMisPedidos(token));
        }


    }
}
