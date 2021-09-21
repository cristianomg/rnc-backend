using _4Lab.Core.Audit;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace _4Lab.Core.Data
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;

        }
        public DbSet<Historic> Historic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
