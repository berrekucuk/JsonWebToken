using _03.JsonWebToken.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace _03.JsonWebToken.Models.ORM
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<WebUser> WebUsers { get; set; }
    }
}
