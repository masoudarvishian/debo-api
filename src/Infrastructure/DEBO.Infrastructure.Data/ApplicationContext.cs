using DEBO.Core.Entity.Category;
using DEBO.Core.Entity.User;
using DEBO.Infrastructure.Data.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace DEBO.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
        }
    }
}
