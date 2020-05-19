using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoXamarin.Models
{
    public class LoginModel
    {
        public String Email { get; set; }
        public String passwd { get; set; }

        public LoginModel() { }
        public LoginModel(string Email, string passwd)
        {
            this.Email = Email;
            this.passwd = passwd;
        }
    }
}
