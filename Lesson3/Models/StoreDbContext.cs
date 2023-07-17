using Lesson3.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson3.Models
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> contextOptions) : base(contextOptions)
        {

        }

        public void Add_Product(Product product)
        {
            Products.Add(product);
            SaveChanges();
        }

        public DbSet<Product> Products { get; set; }
    }
}
