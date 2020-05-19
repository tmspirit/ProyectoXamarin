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

        private int _precio;
        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private int _potencia;
        public int Potencia
        {
            get { return _potencia; }
            set { _potencia = value; }
        }

        private int _maxPar;
        public int Max_Par
        {
            get { return _maxPar; }
            set { _maxPar = value; }
        }
        private int _consumo;
        public int Consumo
        {
            get { return _consumo; }
            set { _consumo = value; }
        }
        private int _stock;
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
    }
}
