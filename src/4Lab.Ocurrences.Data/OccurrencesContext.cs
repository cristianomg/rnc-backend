﻿using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.Data;
using _4Lab.Core.DomainObjects.Enums;
using _4Lab.Core.DomainObjects.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace _4lab.Occurrences.Data
{
    public class OccurrencesContext : CoreContext
    {
        public OccurrencesContext(DbContextOptions<OccurrencesContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        public DbSet<OccurrenceRegister> OccurrenceRegisters { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }
        public DbSet<TypeOccurrence> OccurrenceTypes { get; set; }
        public DbSet<Setor> Setors { get; set; }
        public DbSet<ActionPlain> ActionPlains { get; set; }
        public DbSet<ActionPlainQuestion> ActionPlainQuestions { get; set; }
        public DbSet<ActionPlainResponse> ActionPlainResponses { get; set; }
        public DbSet<RootCauseAnalysis> RootCauseAnalyses { get; set; }
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
            modelBuilder.Entity<TypeOccurrence>().HasData(new TypeOccurrence
            {
                Id = OccurrenceType.PreAnalitica,
                OccurrenceTypeName = OccurrenceType.PreAnalitica.GetDescription(),
            });
            modelBuilder.Entity<TypeOccurrence>().HasData(new TypeOccurrence
            {
                Id = OccurrenceType.Analitica,
                OccurrenceTypeName = OccurrenceType.PreAnalitica.GetDescription(),
            });
            modelBuilder.Entity<TypeOccurrence>().HasData(new TypeOccurrence
            {
                Id = OccurrenceType.PosAnalitica,
                OccurrenceTypeName = OccurrenceType.PreAnalitica.GetDescription(),
            });
        }
    }
}
