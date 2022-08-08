using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Логин пользователя")]
        public string Name { get; set; }
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }        
    }
}
