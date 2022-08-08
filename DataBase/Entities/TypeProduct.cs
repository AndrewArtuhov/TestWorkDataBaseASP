using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class TypeProduct 
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Тип товара")]
        public string Name { get; set; }
        [Display(Name = "Описание товара")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
