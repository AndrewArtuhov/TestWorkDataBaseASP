using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Entities
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Валюта в которой указана цена")]
        public string Currency { get; set; }
        [Display(Name = "Цена")]
        public decimal Value { get; set; }
        public List<Product> Products { get; set; }
    }
}
