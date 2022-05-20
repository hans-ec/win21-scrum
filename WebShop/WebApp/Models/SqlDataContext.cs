using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class SqlDataContext : DbContext
    {
        public SqlDataContext()
        {

        }

        public SqlDataContext(DbContextOptions<SqlDataContext> options) : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
    }
}
