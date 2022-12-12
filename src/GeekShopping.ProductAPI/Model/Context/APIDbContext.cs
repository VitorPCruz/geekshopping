using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class APIDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public APIDbContext() { }
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        { }
    }
}
