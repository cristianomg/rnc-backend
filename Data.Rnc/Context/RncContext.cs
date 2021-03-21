using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Data.Rnc.Context
{
    public sealed class RncContext: DbContext
    {
        public RncContext(DbContextOptions<RncContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<UserPermission>().HasData(
                Enum.GetValues(typeof(UserPermissionType))
                    .Cast<UserPermissionType>()
                    .Select(x => new UserPermission()
                    {
                        Id = x,
                        Name = x.ToString(),
                        Active = true,
                    }));

            modelBuilder.Entity<TipoNaoConformidade>().HasData(new TipoNaoConformidade
            {
                Id = 1,
                NomeTipoNaoConformidade = "Pre-Analitica",
            });
            modelBuilder.Entity<TipoNaoConformidade>().HasData(new TipoNaoConformidade
            {
                Id = 2,
                NomeTipoNaoConformidade = "Analitica",
            });
            modelBuilder.Entity<TipoNaoConformidade>().HasData(new TipoNaoConformidade
            {
                Id = 3,
                NomeTipoNaoConformidade = "Pos-Analitica",
            });

            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 1,
                TipoNaoConformidadeId = 1,
                Descricao = "Erros de cadastro do paciente ou médico.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 2,
                TipoNaoConformidadeId = 1,
                Descricao = "Requisições ilegíveis.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 3,
                TipoNaoConformidadeId = 1,
                Descricao = "Paciente com preparo inadequado.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 4,
                TipoNaoConformidadeId = 1,
                Descricao = "Incidente com cliente.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 5,
                TipoNaoConformidadeId = 1,
                Descricao = "Amostra insuficiente.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 6,
                TipoNaoConformidadeId = 1,
                Descricao = "Tubo inadequado.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 7,
                TipoNaoConformidadeId = 1,
                Descricao = "Amostra com identificação errada ou incompleta.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 8,
                TipoNaoConformidadeId = 2,
                Descricao = "Material não tirado da pendência.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 9,
                TipoNaoConformidadeId = 2,
                Descricao = "Equipamento em manutenção.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 10,
                TipoNaoConformidadeId = 2,
                Descricao = "Perda de amostra.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 11,
                TipoNaoConformidadeId = 2,
                Descricao = "Material fora da validade.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 12,
                TipoNaoConformidadeId = 2,
                Descricao = "Centrifugação incorreta.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 13,
                TipoNaoConformidadeId = 2,
                Descricao = "Queda de energia.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 14,
                TipoNaoConformidadeId = 2,
                Descricao = "Armazenamento errado da amostra.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 15,
                TipoNaoConformidadeId = 3,
                Descricao = "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 16,
                TipoNaoConformidadeId = 3,
                Descricao = "Laudos entregues trocados.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 17,
                TipoNaoConformidadeId = 3,
                Descricao = "Atraso na liberação do laudo.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 18,
                TipoNaoConformidadeId = 3,
                Descricao = "Falta da assinatura do Biomédico no laudo.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 19,
                TipoNaoConformidadeId = 3,
                Descricao = "Erro de transcrição de resultado na ficha de bancada.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 20,
                TipoNaoConformidadeId = 3,
                Descricao = "Questionamento do resultado feito pelo médico ou cliente.",
            });
            modelBuilder.Entity<NaoConformidade>().HasData(new NaoConformidade
            {
                Id = 21,
                TipoNaoConformidadeId = 3,
                Descricao = "Perda do laudo.",
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
