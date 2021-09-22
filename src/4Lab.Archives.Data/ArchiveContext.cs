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
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
