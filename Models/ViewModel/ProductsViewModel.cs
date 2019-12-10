using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase.Models.ViewModel
{
    public class ProductsViewModel
    {
        public Products Products { get; set; }
        public IEnumerable<ProductTypes> ProductTypes { get; set; }
    }
}
