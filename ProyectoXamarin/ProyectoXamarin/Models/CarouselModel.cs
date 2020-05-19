using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoXamarin.Models
{
    public class CarouselModel
    {
        public CarouselModel(int motorId ,string nombre, string descripcion, string imagen)
        {
            MotorId = motorId;
            Nombre = nombre;
            Descripcion = descripcion;
            Image = imagen;
        }
        private int _motorId;
        public int MotorId
        {
            get { return _motorId; }
            set { _motorId = value; }
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
