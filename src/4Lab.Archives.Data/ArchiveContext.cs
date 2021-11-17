using _4Lab.Core.Audit;
using _4Lab.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace _4Lab.Archives.Data
{
    public class ArchiveContext : CoreContext
    {
        public ArchiveContext(DbContextOptions<ArchiveContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Storage");
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Historic>().ToTable(nameof(Historic), "Audit", t => t.ExcludeFromMigrations());

        }
    }
}
