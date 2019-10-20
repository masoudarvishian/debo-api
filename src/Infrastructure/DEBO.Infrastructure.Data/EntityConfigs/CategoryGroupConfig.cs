using DEBO.Core.Entity.CategoryGroup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEBO.Infrastructure.Data.EntityConfigs
{
    public class CategoryGroupConfig : IEntityTypeConfiguration<CategoryGroup>
    {
        public void Configure(EntityTypeBuilder<CategoryGroup> builder)
        {
            builder.ToTable("CategoryGroups");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
        }
    }
}
