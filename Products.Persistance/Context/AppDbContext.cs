using Microsoft.EntityFrameworkCore;
using Products.Persistence.Entities;

namespace Products.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductShop> ProductShops { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
}
