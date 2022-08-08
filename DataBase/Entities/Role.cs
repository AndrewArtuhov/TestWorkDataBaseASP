using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataBase.Entities.Enum;

namespace DataBase.Entities
{
    public class Role
    {
        [Display(Name = "Роль")]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
