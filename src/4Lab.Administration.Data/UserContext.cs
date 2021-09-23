using _4Lab.Administration.Domain.Models;
using _4Lab.Core.Audit;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace _4lab.Administration.Data
{
    public class UserContext : CoreContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAuth> UserAuths { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Historic>().ToTable(nameof(Historic), "Audit", t => t.ExcludeFromMigrations());

            SeedUserPermission(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedUserPermission(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermission>().
                HasData(Enum.GetValues(typeof(UserPermissionType))
                    .Cast<UserPermissionType>()
                    .Select(x => new UserPermission(x, x.ToString())
                    {
                        Active = true,
                    }));
        }
    }
}
