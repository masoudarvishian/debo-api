using DEBO.Core.Entity.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEBO.Infrastructure.Data.EntityConfigs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.Property(x => x.Role).IsRequired();
            builder.Property(x => x.IsDelete).IsRequired();
            builder.Property(x => x.ModifyDate).IsRequired();
            builder.Property(x => x.CreateDate).IsRequired();
        }
    }
}
