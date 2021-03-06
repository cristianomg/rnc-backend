using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Data.Rnc.Context
{
    public sealed class RncContext: DbContext
    {
        public RncContext(DbContextOptions<RncContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<UserPermission>().HasData(
                Enum.GetValues(typeof(UserPermissionType))
                    .Cast<UserPermissionType>()
                    .Select(x => new UserPermission()
                    {
                        Id = x,
                        Name = x.ToString(),
                        Active = true,
                    }));
            base.OnModelCreating(modelBuilder);
        }
    }
}
