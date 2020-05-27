using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoXamarin.ViewModels
{
    public class ComentariosViewModel : ViewModelBase
    {
        RepositoryMotores repo;
        public ComentariosViewModel(RepositoryMotores repo)
        {
            this.repo = repo;
            Task.Run(() => GetComentariosAsync());
        }

        private int _productoID;
        public int ProductoID
        {
            get { return _productoID; }
            set { _productoID = value; OnPropertyChanged("ProductoID"); }
        }

        private ObservableCollection<Comentario> _comentarios;
        public ObservableCollection<Comentario> Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; OnPropertyChanged("Comentarios"); }
        }

        public async Task GetComentariosAsync()
        {
            string token = Application.Current.Properties["Token"].ToString();
            if (token != "")
            {
                List<Comentario> comentarios = new List<Comentario>();
                do
                {
                    comentarios = await repo.GetComentarios(ProductoID);
                    foreach (Comentario c in comentarios)
                    {
                        Clientes cliente = await repo.FindCliente(c.IdCliente, token);
                        c.Clientes = cliente;
                    }
                } while (comentarios.Count <= 0);
                
                Comentarios = new ObservableCollection<Comentario>(comentarios);
            }
        }
    }
}
