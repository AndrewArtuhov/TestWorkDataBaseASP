using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Register
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
