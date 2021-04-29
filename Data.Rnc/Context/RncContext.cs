using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Domain.Dtos.Helps;
using System.Collections.Generic;

namespace Data.Rnc.Context
{
    public sealed class RncContext : DbContext
    {
        public RncContext(DbContextOptions<RncContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<NonComplianceRegister> NonComplianceRegisters { get; set; }
        public DbSet<NonCompliance> NonCompliance { get; set; }
        public DbSet<TypeNonCompliance> TypeNonCompliance { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAuth> UserAuths { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Setor> Setors { get; set; }
        public DbSet<ActionPlain> ActionPlains { get; set; }
        public DbSet<ActionPlainQuestion> ActionPlainQuestions { get; set; }
        public DbSet<ActionPlainResponse> ActionPlainResponses { get; set; }
        public DbSet<RootCauseAnalysis> RootCauseAnalyses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedUserPermission(modelBuilder);
            SeedSetor(modelBuilder);
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

        private void SeedSetor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setor>().HasData(
               Enum.GetValues(typeof(SetorType))
                   .Cast<SetorType>()
                   .Select(x => new Setor()
                   {
                       Id = x,
                       Name = x.ToString(),
                       Active = true,
                   }));
        }

        private void SeedUserPermission(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermission>().HasData(
                Enum.GetValues(typeof(UserPermissionType))
                    .Cast<UserPermissionType>()
                    .Select(x => new UserPermission()
                    {
                        Id = x,
                        Name = x.ToString(),
                        Active = true,
                    }));
        }
    }
}
