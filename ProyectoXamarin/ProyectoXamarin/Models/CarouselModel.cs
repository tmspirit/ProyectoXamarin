using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoXamarin.Models
{
    public class CarouselModel
    {
        public CarouselModel(int cocheId ,string nombreString, string descripcionString, string imageString)
        {
            CocheId = cocheId;
            Nombre = nombreString;
            Descripcion = descripcionString;
            Image = imageString;
        }
        private int _cocheId;
        public int CocheId
        {
            get { return _cocheId; }
            set { _cocheId = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
