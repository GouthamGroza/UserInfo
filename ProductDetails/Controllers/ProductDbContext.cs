using Microsoft.EntityFrameworkCore;
using ProductDetails.Models;

namespace ProductDetails.Controllers
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) 
            : base(options)
        {

        }

        public DbSet<ProductDetail> ProductDetails { get; set; }
    }
}
