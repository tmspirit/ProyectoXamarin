using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProyectoXamarin.Code
{
    public class MasterPageItem
    {
        public String Titulo { get; set; }
        public Type Pagina { get; set; }
        public String Imagen { get; set; }
        public Command miCommand { get; set; }

        public static implicit operator Command(MasterPageItem v)
        {
            throw new NotImplementedException();
        }
    }
}
