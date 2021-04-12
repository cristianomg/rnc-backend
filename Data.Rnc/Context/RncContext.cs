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
            SeedNaoConformidade(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        private void SeedNaoConformidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 1,
                TypeNonComplianceId = 1,
                Description = "Erros de cadastro do paciente ou médico.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 2,
                TypeNonComplianceId = 1,
                Description = "Requisições ilegíveis.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 3,
                TypeNonComplianceId = 1,
                Description = "Paciente com preparo inadequado.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 4,
                TypeNonComplianceId = 1,
                Description = "Incidente com cliente.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 5,
                TypeNonComplianceId = 1,
                Description = "Amostra insuficiente.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 6,
                TypeNonComplianceId = 1,
                Description = "Tubo inadequado.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 7,
                TypeNonComplianceId = 1,
                Description = "Amostra com identificação errada ou incompleta.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 8,
                TypeNonComplianceId = 2,
                Description = "Material não tirado da pendência.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 9,
                TypeNonComplianceId = 2,
                Description = "Equipamento em manutenção.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 10,
                TypeNonComplianceId = 2,
                Description = "Perda de amostra.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 11,
                TypeNonComplianceId = 2,
                Description = "Material fora da validade.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 12,
                TypeNonComplianceId = 2,
                Description = "Centrifugação incorreta.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 13,
                TypeNonComplianceId = 2,
                Description = "Queda de energia.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 14,
                TypeNonComplianceId = 2,
                Description = "Armazenamento errado da amostra.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 15,
                TypeNonComplianceId = 3,
                Description = "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 16,
                TypeNonComplianceId = 3,
                Description = "Laudos entregues trocados.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 17,
                TypeNonComplianceId = 3,
                Description = "Atraso na liberação do laudo.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 18,
                TypeNonComplianceId = 3,
                Description = "Falta da assinatura do Biomédico no laudo.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 19,
                TypeNonComplianceId = 3,
                Description = "Erro de transcrição de resultado na ficha de bancada.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 20,
                TypeNonComplianceId = 3,
                Description = "Questionamento do resultado feito pelo médico ou cliente.",
            });
            modelBuilder.Entity<NonCompliance>().HasData(new NonCompliance
            {
                Id = 21,
                TypeNonComplianceId = 3,
                Description = "Perda do laudo.",
            });
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
