using DEBO.Core.Entity;
using DEBO.Core.Entity.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace DEBO.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Apply all configurations

            Assembly assemblyWithConfigurations = GetType()
                .Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(
                assemblyWithConfigurations);

            #endregion

            #region Apply all DbSet<T>

            var entityMethod =
                typeof(ModelBuilder).GetMethods()
                    .FirstOrDefault(method =>
                        method.Name == nameof(modelBuilder.Entity) &&
                        method.IsGenericMethod == false);

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var entityTypes = from x in assembly.GetTypes()
                    where x.IsSubclassOf(typeof(IEntity))
                    select x;

                foreach (var type in entityTypes)
                {
                    if (entityMethod != null)
                    {
                        entityMethod.MakeGenericMethod(type)
                            .Invoke(modelBuilder,
                                new object[]
                                {
                                });
                    }
                }
            }

            #endregion
        }
    }
}