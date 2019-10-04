﻿using DEBO.Core.Entity.Contact;
using DEBO.Core.Entity.User;
using DEBO.Infrastructure.Data.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace DEBO.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ContactConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
