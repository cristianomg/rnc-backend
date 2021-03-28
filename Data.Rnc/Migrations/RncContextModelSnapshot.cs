﻿// <auto-generated />
using System;
using Data.Rnc.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    [DbContext(typeof(RncContext))]
    partial class RncContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Entities.NaoConformidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<int>("TipoNaoConformidadeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TipoNaoConformidadeId");

                    b.ToTable("NaoConformidade");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(493),
                            Descricao = "Erros de cadastro do paciente ou médico.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1542),
                            Descricao = "Requisições ilegíveis.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1599),
                            Descricao = "Paciente com preparo inadequado.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1619),
                            Descricao = "Incidente com cliente.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1638),
                            Descricao = "Amostra insuficiente.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1658),
                            Descricao = "Tubo inadequado.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1676),
                            Descricao = "Amostra com identificação errada ou incompleta.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1694),
                            Descricao = "Material não tirado da pendência.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 9,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1711),
                            Descricao = "Equipamento em manutenção.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 10,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1730),
                            Descricao = "Perda de amostra.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 11,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1748),
                            Descricao = "Material fora da validade.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 12,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1766),
                            Descricao = "Centrifugação incorreta.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 13,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1783),
                            Descricao = "Queda de energia.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 14,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1833),
                            Descricao = "Armazenamento errado da amostra.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 15,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1852),
                            Descricao = "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 16,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1869),
                            Descricao = "Laudos entregues trocados.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 17,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1886),
                            Descricao = "Atraso na liberação do laudo.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 18,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1905),
                            Descricao = "Falta da assinatura do Biomédico no laudo.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 19,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1922),
                            Descricao = "Erro de transcrição de resultado na ficha de bancada.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 20,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1939),
                            Descricao = "Questionamento do resultado feito pelo médico ou cliente.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 21,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 239, DateTimeKind.Local).AddTicks(1956),
                            Descricao = "Perda do laudo.",
                            TipoNaoConformidadeId = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.NonComplianceRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ImmediateAction")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("MoreInformation")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("NonComplianceId")
                        .HasColumnType("integer");

                    b.Property<string>("PeopleInvolved")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RegisterHour")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NonComplianceId");

                    b.HasIndex("UserId");

                    b.ToTable("NonComplianceRegister");
                });

            modelBuilder.Entity("Domain.Entities.RootCauseAnalysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Analyze")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("NonComplianceRegisterId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NonComplianceRegisterId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("RootCauseAnalysis");
                });

            modelBuilder.Entity("Domain.Entities.Setor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Setor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(4437),
                            Name = "Coleta"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(6182),
                            Name = "Microbiologia"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(6259),
                            Name = "Parasitologia"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(6263),
                            Name = "Imunologia"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(6265),
                            Name = "Hematologia"
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(6270),
                            Name = "Triagem"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TipoNaoConformidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NomeTipoNaoConformidade")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("TipoNaoConformidades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(7900),
                            NomeTipoNaoConformidade = "Pre-Analitica"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(9790),
                            NomeTipoNaoConformidade = "Analitica"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 238, DateTimeKind.Local).AddTicks(9833),
                            NomeTipoNaoConformidade = "Pos-Analitica"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Crbm")
                        .IsRequired()
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 3, 28, 18, 43, 26, 232, DateTimeKind.Local).AddTicks(4215));

                    b.Property<string>("Enrollment")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<int>("SetorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserAuthId")
                        .HasColumnType("integer");

                    b.Property<int>("UserPermissionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Enrollment")
                        .IsUnique();

                    b.HasIndex("SetorId");

                    b.HasIndex("UserAuthId")
                        .IsUnique();

                    b.HasIndex("UserPermissionId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.UserAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 3, 28, 18, 43, 26, 226, DateTimeKind.Local).AddTicks(2372));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("UserAuth");
                });

            modelBuilder.Entity("Domain.Entities.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("UserPermission");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 236, DateTimeKind.Local).AddTicks(9406),
                            Name = "Employee"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 237, DateTimeKind.Local).AddTicks(1370),
                            Name = "Supervisor"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 28, 18, 43, 26, 237, DateTimeKind.Local).AddTicks(1496),
                            Name = "QualityBiomedical"
                        });
                });

            modelBuilder.Entity("Domain.Entities.NaoConformidade", b =>
                {
                    b.HasOne("Domain.Entities.TipoNaoConformidade", "TipoNaoConformidade")
                        .WithMany("NaoConformidades")
                        .HasForeignKey("TipoNaoConformidadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.NonComplianceRegister", b =>
                {
                    b.HasOne("Domain.Entities.NaoConformidade", "NonCompliance")
                        .WithMany("NonCompliceRegisters")
                        .HasForeignKey("NonComplianceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("NonComplianceRegisters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.RootCauseAnalysis", b =>
                {
                    b.HasOne("Domain.Entities.NonComplianceRegister", "NonComplianceRegister")
                        .WithOne("RootCauseAnalysis")
                        .HasForeignKey("Domain.Entities.RootCauseAnalysis", "NonComplianceRegisterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("AnalyzeRootCauses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Setor", "Setor")
                        .WithMany("Users")
                        .HasForeignKey("SetorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserAuth", "UserAuth")
                        .WithOne("User")
                        .HasForeignKey("Domain.Entities.User", "UserAuthId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserPermission", "UserPermission")
                        .WithMany("Users")
                        .HasForeignKey("UserPermissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
