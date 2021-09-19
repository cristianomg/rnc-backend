using Domain.Dtos.Helps;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Data.Rnc.Context
{
    public sealed class RncContext : DbContext
    {
        public RncContext(DbContextOptions<RncContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        private RncContext()
        {

        }

        public DbSet<NonComplianceRegister> NonComplianceRegisters { get; set; }
        public DbSet<Archive> Archives { get; set; }
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
                Id = (int)DtoNonComplianceType.PreAnalitica,
                NameNonCompliance = "Pre-Analitica",
            });
            modelBuilder.Entity<TypeNonCompliance>().HasData(new TypeNonCompliance
            {
                Id = (int)DtoNonComplianceType.Analitica,
                NameNonCompliance = "Analitica",
            });
            modelBuilder.Entity<TypeNonCompliance>().HasData(new TypeNonCompliance
            {
                Id = (int)DtoNonComplianceType.PosAnalitica,
                NameNonCompliance = "Pos-Analitica",
            });
        }
    }
}
