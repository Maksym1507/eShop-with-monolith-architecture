using Microsoft.EntityFrameworkCore;
using IdentiyServer4.Entities;

namespace IdentityServer4.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; } = null!;
    }
}
