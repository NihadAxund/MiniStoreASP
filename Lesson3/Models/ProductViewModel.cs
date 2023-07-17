using Lesson3.Entities;
using System.Collections.Generic;

namespace Lesson3.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public Product product { get; set; } = new Product();
        public ProductViewModel() {
       
        }

        public ProductViewModel(List<Product> products) {
            Products = products;
        }
    }
}
