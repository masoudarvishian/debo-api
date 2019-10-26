using DEBO.Core.Entity.CategoryGroupCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEBO.Infrastructure.Data.EntityConfigs
{
    public class CategoryGroupCategoryConfig :
        IEntityTypeConfiguration<CategoryGroupCategory>
    {
        public void Configure(EntityTypeBuilder<CategoryGroupCategory> builder)
        {
            builder.HasKey(x => new
            {
                x.CategoryId,
                x.CategoryGroupId
            });

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.CategoryGroupLinks)
                .HasForeignKey(x => x.CategoryId);

            builder
                .HasOne(x => x.CategoryGroup)
                .WithMany(x => x.CategoryLinks)
                .HasForeignKey(x => x.CategoryGroupId);
        }
    }
}