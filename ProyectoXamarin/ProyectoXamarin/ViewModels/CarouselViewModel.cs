using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoXamarin.ViewModels
{
    public class CarouselViewModel
    {
        RepositoryMotores repo;
        private Task TaskProductos;
        public CarouselViewModel(RepositoryMotores repo)
        {
            this.repo = repo;
            TaskProductos = GetProductosAsync();
        }
        private ObservableCollection<CarouselModel> _imageCollection = new ObservableCollection<CarouselModel>();
        public ObservableCollection<CarouselModel> ImageCollection
        {
            get { return _imageCollection; }
            set { _imageCollection = value; }
        }

        public async Task GetProductosAsync()
        {
            List<Productos> productos = await repo.GetProductos();
            foreach (Productos prod in productos)
            {
                ImageCollection.Add(new CarouselModel(prod.Id_motor, prod.Nombre, prod.Descripcion, prod.Imagen));
            }
        }
    }
}
