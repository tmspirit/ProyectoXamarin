using ProyectoXamarin.Base;
using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ProyectoXamarin.ViewModels
{
    public class DetallesProductoViewModel : ViewModelBase
    {
        RepositoryMotores repo;
        public DetallesProductoViewModel(RepositoryMotores repo)
        {
            this.repo = repo;
            Task.Run(async () => await GetProductoAsync());
        }

        private int _motorId;
        public int MotorID
        {
            get { return _motorId; }
            set { _motorId = value; OnPropertyChanged("MotorID"); }
        }

        private ObservableCollection<Productos> _productos;
        public ObservableCollection<Productos> Productos
        {
            get { return _productos; }
            set { _productos = value; OnPropertyChanged("Productos"); }
        }

        public async Task<ObservableCollection<Productos>> GetProductoAsync()
        {
            ObservableCollection<Productos> productos = new ObservableCollection<Productos>();
            Productos produ = await repo.GetProducto(MotorID);
            productos.Add(produ);
            return productos;
        }
    }
}
