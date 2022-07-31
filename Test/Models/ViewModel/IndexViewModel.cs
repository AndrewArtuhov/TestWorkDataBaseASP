using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.ModelsDB.Entities;

namespace Test.Models.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<TypeProduct> TypeProducts { get; set; }
        public IEnumerable<Price> Prices { get; set; }
    }
}
