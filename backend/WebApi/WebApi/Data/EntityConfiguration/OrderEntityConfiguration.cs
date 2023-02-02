using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Data.Entities;

namespace WebApi.Data.EntityConfiguration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Country).IsRequired();
            builder.Property(p => p.Region).IsRequired();
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.Index).IsRequired();

            builder.Property(p => p.CreatedAt).HasColumnType("date");
            builder.Property(p => p.TotalSum).HasColumnType("money");

            builder.HasOne(h => h.User)
                .WithMany(w => w.Orders)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
