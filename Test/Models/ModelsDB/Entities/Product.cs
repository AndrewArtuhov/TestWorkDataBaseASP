using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.ModelsDB.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название товара")]
        public string Name { get; set; }

        [Display(Name = "Цена товара")]
        public Price Price { get; set; }

        [Display(Name = "Количество товара")]
        public int Count { get; set; }

        [Display(Name = "Штрихкод товара")]
        public string Barcode { get; set; }

        [Display(Name = "Последняя дата обновления")]
        public DateTime DateUpdate { get; set; }

        [Display(Name = "Тип товара")]
        public TypeProduct Type { get; set; }
    }
}
