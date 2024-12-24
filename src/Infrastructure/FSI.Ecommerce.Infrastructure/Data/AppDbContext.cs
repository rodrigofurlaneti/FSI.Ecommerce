using FSI.Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FSI.Ecommerce.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CategoryEntity> Ecommerce_Categories { get; set; } = null!;
        public DbSet<CommandEntity> Ecommerce_Commands { get; set; } = null!;
        public DbSet<UserEntity> Ecommerce_Users { get; set; } = null!;
        public DbSet<OrderEntity> Ecommerce_Orders { get; set; } = null!;
        public DbSet<ProfileEntity> Ecommerce_Profiles { get; set; } = null!;
        public DbSet<ProductEntity> Ecommerce_Products { get; set; } = null!;
    }
}
