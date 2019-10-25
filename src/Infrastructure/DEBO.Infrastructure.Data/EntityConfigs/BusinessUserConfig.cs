using DEBO.Core.Entity.BusinessUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEBO.Infrastructure.Data.EntityConfigs
{
    public class BusinessUserConfig : IEntityTypeConfiguration<BusinessUser>
    {
        public void Configure(EntityTypeBuilder<BusinessUser> builder)
        {
            builder.HasKey(x => new
            {
                x.UserId,
                x.BusinessId
            });

            builder
                .HasOne(x => x.Business)
                .WithMany(x => x.BusinessUsers)
                .HasForeignKey(x => x.BusinessId);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.BusinessUsers)
                .HasForeignKey(x => x.UserId);
        }
    }
}
