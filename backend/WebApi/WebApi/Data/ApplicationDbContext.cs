using Microsoft.EntityFrameworkCore;
using WebApi.Data.Configuration;
using WebApi.Data.Entities;
using WebApi.Data.EntityConfiguration;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories { get; set; } = null!;

        public DbSet<ProductEntity> Products { get; set; } = null!;

        public DbSet<UserEntity> Users { get; set; } = null!;

        public DbSet<OrderEntity> Orders { get; set; } = null!;

        public DbSet<OrderProductEntity> OrderProducts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductEntityConfiguration());
            modelBuilder.UseHiLo();
        }
    }
}
