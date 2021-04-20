﻿// <auto-generated />
using System;
using Data.Rnc.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Rnc.Migrations
{
    [DbContext(typeof(RncContext))]
    [Migration("20210411201639_Rnc")]
    partial class Rnc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Entities.ActionPlain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ActionPlain");
                });

            modelBuilder.Entity("Domain.Entities.ActionPlainQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ActionPlainId")
                        .HasColumnType("integer");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ActionPlainId");

                    b.ToTable("ActionPlainQuestion");
                });

            modelBuilder.Entity("Domain.Entities.ActionPlainResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ActionPlainId")
                        .HasColumnType("integer");

                    b.Property<int>("ActionPlainQuestionId")
                        .HasColumnType("integer");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("RootCauseAnalysisId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ActionPlainId");

                    b.HasIndex("ActionPlainQuestionId");

                    b.HasIndex("RootCauseAnalysisId");

                    b.ToTable("ActionPlainResponse");
                });

            modelBuilder.Entity("Domain.Entities.NonCompliance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<int>("TypeNonComplianceId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TypeNonComplianceId");

                    b.ToTable("NonCompliance");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(1814),
                            Description = "Erros de cadastro do paciente ou médico.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3169),
                            Description = "Requisições ilegíveis.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3242),
                            Description = "Paciente com preparo inadequado.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3264),
                            Description = "Incidente com cliente.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3283),
                            Description = "Amostra insuficiente.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3307),
                            Description = "Tubo inadequado.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3325),
                            Description = "Amostra com identificação errada ou incompleta.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3344),
                            Description = "Material não tirado da pendência.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 9,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3362),
                            Description = "Equipamento em manutenção.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 10,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3382),
                            Description = "Perda de amostra.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 11,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3400),
                            Description = "Material fora da validade.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 12,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3418),
                            Description = "Centrifugação incorreta.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 13,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3435),
                            Description = "Queda de energia.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 14,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3453),
                            Description = "Armazenamento errado da amostra.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 15,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3471),
                            Description = "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 16,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3580),
                            Description = "Laudos entregues trocados.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 17,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3598),
                            Description = "Atraso na liberação do laudo.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 18,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3618),
                            Description = "Falta da assinatura do Biomédico no laudo.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 19,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3700),
                            Description = "Erro de transcrição de resultado na ficha de bancada.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 20,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3720),
                            Description = "Questionamento do resultado feito pelo médico ou cliente.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 21,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 165, DateTimeKind.Local).AddTicks(3738),
                            Description = "Perda do laudo.",
                            TypeNonComplianceId = 3
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

                    b.Property<int>("SetorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NonComplianceId");

                    b.HasIndex("SetorId");

                    b.HasIndex("UserId");

                    b.ToTable("NonComplianceRegister");
                });

            modelBuilder.Entity("Domain.Entities.RootCauseAnalysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ActionPlainId")
                        .HasColumnType("integer");

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

                    b.HasIndex("ActionPlainId");

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
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(845),
                            Name = "Coleta"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2573),
                            Name = "Microbiologia"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2701),
                            Name = "Parasitologia"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2705),
                            Name = "Imunologia"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2707),
                            Name = "Hematologia"
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(2713),
                            Name = "Triagem"
                        });
                });

            modelBuilder.Entity("Domain.Entities.TypeNonCompliance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NameNonCompliance")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("TypeNonCompliance");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(6720),
                            NameNonCompliance = "Pre-Analitica"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(8788),
                            NameNonCompliance = "Analitica"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 163, DateTimeKind.Local).AddTicks(8844),
                            NameNonCompliance = "Pos-Analitica"
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
                        .HasDefaultValue(new DateTime(2021, 4, 11, 17, 16, 39, 156, DateTimeKind.Local).AddTicks(2089));

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
                        .HasDefaultValue(new DateTime(2021, 4, 11, 17, 16, 39, 150, DateTimeKind.Local).AddTicks(6154));

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
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 161, DateTimeKind.Local).AddTicks(3558),
                            Name = "Employee"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 161, DateTimeKind.Local).AddTicks(5493),
                            Name = "Supervisor"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 11, 17, 16, 39, 161, DateTimeKind.Local).AddTicks(5733),
                            Name = "QualityBiomedical"
                        });
                });

            modelBuilder.Entity("Domain.Entities.ActionPlainQuestion", b =>
                {
                    b.HasOne("Domain.Entities.ActionPlain", "ActionPlain")
                        .WithMany("Questions")
                        .HasForeignKey("ActionPlainId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ActionPlainResponse", b =>
                {
                    b.HasOne("Domain.Entities.ActionPlain", "ActionPlain")
                        .WithMany("Responses")
                        .HasForeignKey("ActionPlainId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ActionPlainQuestion", "ActionPlainQuestion")
                        .WithMany("ActionPlainResponse")
                        .HasForeignKey("ActionPlainQuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.RootCauseAnalysis", "RootCauseAnalysis")
                        .WithMany("ActionPlainResponses")
                        .HasForeignKey("RootCauseAnalysisId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.NonCompliance", b =>
                {
                    b.HasOne("Domain.Entities.TypeNonCompliance", "TypeNonCompliance")
                        .WithMany("NonCompliances")
                        .HasForeignKey("TypeNonComplianceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.NonComplianceRegister", b =>
                {
                    b.HasOne("Domain.Entities.NonCompliance", "NonCompliance")
                        .WithMany("NonCompliceRegisters")
                        .HasForeignKey("NonComplianceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Setor", "Setor")
                        .WithMany("NonComplianceRegisters")
                        .HasForeignKey("SetorId")
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
                    b.HasOne("Domain.Entities.ActionPlain", "ActionPlain")
                        .WithMany("RootCauseAnalysis")
                        .HasForeignKey("ActionPlainId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

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