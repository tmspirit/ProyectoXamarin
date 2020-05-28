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
            Task.Run(async () => await GetComentariosAsync());
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

        public async Task<ObservableCollection<Comentario>> GetComentariosAsync()
        {
            string token = Application.Current.Properties["Token"].ToString();
            if (token != "")
            {
                List<Comentario> comen = await repo.GetComentarios(ProductoID);
                foreach (Comentario c in comen)
                {
                    Clientes cliente = await repo.FindCliente(c.IdCliente, token);
                    c.Clientes = cliente;
                }
                ObservableCollection<Comentario> comentarios = new ObservableCollection<Comentario>(comen);
                return comentarios;
            }
            else return null;
        }
    }
}
