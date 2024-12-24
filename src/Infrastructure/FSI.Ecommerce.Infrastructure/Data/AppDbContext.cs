using FSI.Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FSI.Ecommerce.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Ecommerce_Users { get; set; } = null!;
    }
}
