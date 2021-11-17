using _4Lab.Core.Audit;
using _4Lab.Core.Data;
using _4Lab.Satisfaction.Domain.Entities;
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
        public DbSet<SatisfactionSurvey> SatisfactionSurveys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Historic>().ToTable(nameof(Historic), "Audit", t => t.ExcludeFromMigrations());

            modelBuilder.HasDefaultSchema("Satisfaction");
        }
    }
}
