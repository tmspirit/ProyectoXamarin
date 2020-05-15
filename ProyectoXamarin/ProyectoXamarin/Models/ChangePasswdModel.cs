using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class ChangePasswdModel
    {
        public String OldPasswd { get; set; }
        public String NewPasswd { get; set; }
        public int IdCliente { get; set; }
    }
}
