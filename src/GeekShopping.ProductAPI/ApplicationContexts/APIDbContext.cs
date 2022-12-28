using GeekShopping.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.ApplicationContexts
{
    public class APIDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public APIDbContext() { }
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
