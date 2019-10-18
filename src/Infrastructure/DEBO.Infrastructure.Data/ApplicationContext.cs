using DEBO.Core.Entity.Category;
using DEBO.Core.Entity.User;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

            // Apply all configurations
            Assembly assemblyWithConfigurations = GetType().Assembly; 
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
    }
}
