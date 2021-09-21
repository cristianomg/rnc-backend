using _4lab.Ocurrences.Domain.Models;
using _4Lab.Core.Audit;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace _4lab.Ocurrences.Data
{
    public class OcurrencesContext : DbContext
    {
        public OcurrencesContext(DbContextOptions<OcurrencesContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        private OcurrencesContext() { }

        public DbSet<NonComplianceRegister> NonComplianceRegisters { get; set; }
        public DbSet<NonCompliance> NonCompliance { get; set; }
        public DbSet<TypeNonCompliance> TypeNonCompliance { get; set; }
        public DbSet<Setor> Setors { get; set; }
        public DbSet<ActionPlain> ActionPlains { get; set; }
        public DbSet<ActionPlainQuestion> ActionPlainQuestions { get; set; }
        public DbSet<ActionPlainResponse> ActionPlainResponses { get; set; }
        public DbSet<RootCauseAnalysis> RootCauseAnalyses { get; set; }
        public DbSet<Historic> Historics { get; set; }
        public DbSet<OccurrenceClassification> OccurrenceClassifications { get; set; }
        public DbSet<FiveWhat> FiveWhats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedTipoNaoConformidade(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        private void SeedTipoNaoConformidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeNonCompliance>().HasData(new TypeNonCompliance
            {
                Id = NonComplianceType.PreAnalitica,
                NameNonCompliance = "Pre-Analitica",
            });
            modelBuilder.Entity<TypeNonCompliance>().HasData(new TypeNonCompliance
            {
                Id = NonComplianceType.Analitica,
                NameNonCompliance = "Analitica",
            });
            modelBuilder.Entity<TypeNonCompliance>().HasData(new TypeNonCompliance
            {
                Id = NonComplianceType.PosAnalitica,
                NameNonCompliance = "Pos-Analitica",
            });
        }
    }
}
