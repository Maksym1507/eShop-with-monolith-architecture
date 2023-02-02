using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data.Configuration
{
    public class OrderProductEntityConfiguration : IEntityTypeConfiguration<OrderProductEntity>
    {
        public void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.ProductId).IsRequired();
            builder.Property(h => h.OrderId).IsRequired();
            builder.Property(p => p.Count).IsRequired();
            builder.Property(p => p.Total).HasColumnType("money");

            builder.HasOne(h => h.Order)
                .WithMany(w => w.OrderProducts)
                .HasForeignKey(h => h.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.Product)
                .WithMany(w => w.OrderProducts)
                .HasForeignKey(h => h.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
