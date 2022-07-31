using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.ModelsDB.Entities
{
    public class Role
    {
        [Display(Name = "Роль")]
        public int Id { get; set; }
    }
}
