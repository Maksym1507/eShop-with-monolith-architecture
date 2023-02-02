using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Data.Entities;

namespace WebApi.Data.EntityConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(p => p.CategoryName).IsRequired();

            builder.HasData(
                new CategoryEntity()
                {
                    Id = 1,
                    CategoryName = "pizza"
                },
                new CategoryEntity()
                {
                    Id = 2,
                    CategoryName = "roll"
                });
        }
    }
}
