using ProyectoXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoXamarin.ViewModels
{
    public class CarouselViewModel
    {
        public CarouselViewModel()
        {
            ImageCollection.Add(new CarouselModel("Ferrari", "Motor fabricado por Ferrari", "https://api.ferrarinetwork.ferrari.com/v2/network-content/medias/resize/5dd560d4f8fc7b0aa906c8ca-line-up-ferrari-812-superfast-v2?apikey=9QscUiwr5n0NhOuQb463QEKghPrVlpaF&width=800&height=600"));
            ImageCollection.Add(new CarouselModel("Ferrari", "Motor fabricado por Ferrari", "https://api.ferrarinetwork.ferrari.com/v2/network-content/medias/resize/5dd560d4f8fc7b0aa906c8ca-line-up-ferrari-812-superfast-v2?apikey=9QscUiwr5n0NhOuQb463QEKghPrVlpaF&width=800&height=600"));
            ImageCollection.Add(new CarouselModel("Ferrari", "Motor fabricado por Ferrari", "https://api.ferrarinetwork.ferrari.com/v2/network-content/medias/resize/5dd560d4f8fc7b0aa906c8ca-line-up-ferrari-812-superfast-v2?apikey=9QscUiwr5n0NhOuQb463QEKghPrVlpaF&width=800&height=600"));
            ImageCollection.Add(new CarouselModel("Ferrari", "Motor fabricado por Ferrari", "https://api.ferrarinetwork.ferrari.com/v2/network-content/medias/resize/5dd560d4f8fc7b0aa906c8ca-line-up-ferrari-812-superfast-v2?apikey=9QscUiwr5n0NhOuQb463QEKghPrVlpaF&width=800&height=600"));

        }
        private List<CarouselModel> imageCollection = new List<CarouselModel>();
        public List<CarouselModel> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }
    }
}
