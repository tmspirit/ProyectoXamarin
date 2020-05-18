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
        RepositoryProductos repo;
        private Task TaskProductos;
        public CarouselViewModel()
        {
            this.repo = new RepositoryProductos();
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
                ImageCollection.Add(new CarouselModel(prod.Id_motor, prod.Nombre, prod.Descripcion, 
                    "https://api.ferrarinetwork.ferrari.com/v2/network-content/medias/resize/5dd560d4f8fc7b0aa906c8ca-line-up-ferrari-812-superfast-v2?apikey=9QscUiwr5n0NhOuQb463QEKghPrVlpaF&width=800&height=600"));
            }
        }
    }
}
