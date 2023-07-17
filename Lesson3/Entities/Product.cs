using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lesson3.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required()]
        [RegularExpression("^[a-zA-Z]+$")]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        [Required()]
        public string Description { get; set; }
        [Required()]
        [Range(0,int.MaxValue)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required()]
        [RegularExpression(@"https?://(?:[a-z0-9-]+\.)+[a-z]{2,}(?:/[^/#?]+)+\.(?:jpe?g|gif|png)$")]
        public string Image_Link { get; set; }

        public Product(string name, string description, decimal price, string ımage_Link)
        {
            Name = name;
            Description = description;
            Price = price;
            Image_Link = ımage_Link;
        }
        public Product() { }
        public void Changing(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Image_Link = product.Image_Link;

        }
    }
}
