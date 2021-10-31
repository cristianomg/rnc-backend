﻿using _4Lab.Core.Audit;
using _4Lab.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace _4Lab.Satisfaction.Data
{
    public class SatisfactionContext : CoreContext
    {
        public SatisfactionContext(DbContextOptions<SatisfactionContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Historic>().ToTable(nameof(Historic), "Audit", t => t.ExcludeFromMigrations());


            base.OnModelCreating(modelBuilder);
        }
    }
}
