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
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

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
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

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
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

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
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("TypeNonComplianceId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TypeNonComplianceId");

                    b.ToTable("NonCompliance");
<<<<<<< HEAD
=======

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(6887),
                            Description = "Erros de cadastro do paciente ou médico.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8732),
                            Description = "Requisições ilegíveis.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8830),
                            Description = "Paciente com preparo inadequado.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8857),
                            Description = "Incidente com cliente.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8946),
                            Description = "Amostra insuficiente.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8975),
                            Description = "Tubo inadequado.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(8998),
                            Description = "Amostra com identificação errada ou incompleta.",
                            TypeNonComplianceId = 1
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9021),
                            Description = "Material não tirado da pendência.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 9,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9043),
                            Description = "Equipamento em manutenção.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 10,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9069),
                            Description = "Perda de amostra.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 11,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9091),
                            Description = "Material fora da validade.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 12,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9114),
                            Description = "Centrifugação incorreta.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 13,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9136),
                            Description = "Queda de energia.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 14,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9158),
                            Description = "Armazenamento errado da amostra.",
                            TypeNonComplianceId = 2
                        },
                        new
                        {
                            Id = 15,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9180),
                            Description = "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 16,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9361),
                            Description = "Laudos entregues trocados.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 17,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9384),
                            Description = "Atraso na liberação do laudo.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 18,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9408),
                            Description = "Falta da assinatura do Biomédico no laudo.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 19,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9430),
                            Description = "Erro de transcrição de resultado na ficha de bancada.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 20,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9452),
                            Description = "Questionamento do resultado feito pelo médico ou cliente.",
                            TypeNonComplianceId = 3
                        },
                        new
                        {
                            Id = 21,
                            Active = true,
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 578, DateTimeKind.Local).AddTicks(9475),
                            Description = "Perda do laudo.",
                            TypeNonComplianceId = 3
                        });
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
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
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("MoreInformation")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("PeopleInvolved")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

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
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 499, DateTimeKind.Local).AddTicks(5566),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 575, DateTimeKind.Local).AddTicks(8484),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
                            Name = "Coleta"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 499, DateTimeKind.Local).AddTicks(6843),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(533),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
                            Name = "Microbiologia"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 499, DateTimeKind.Local).AddTicks(6877),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(658),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
                            Name = "Parasitologia"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 499, DateTimeKind.Local).AddTicks(6879),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(662),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
                            Name = "Imunologia"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 499, DateTimeKind.Local).AddTicks(6881),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(666),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
                            Name = "Hematologia"
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 499, DateTimeKind.Local).AddTicks(6885),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(673),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
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
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 499, DateTimeKind.Local).AddTicks(9795),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(5613),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
                            NameNonCompliance = "Pre-Analitica"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 500, DateTimeKind.Local).AddTicks(1362),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(7593),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
                            NameNonCompliance = "Analitica"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 500, DateTimeKind.Local).AddTicks(1435),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 576, DateTimeKind.Local).AddTicks(7643),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
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

<<<<<<< HEAD
                    b.Property<string>("Crbm")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 4, 29, 19, 39, 57, 494, DateTimeKind.Local).AddTicks(9790));
=======
                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 4, 27, 21, 10, 54, 566, DateTimeKind.Local).AddTicks(1482));
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0

                    b.Property<string>("Enrollment")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

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
<<<<<<< HEAD
                        .HasDefaultValue(new DateTime(2021, 4, 29, 19, 39, 57, 489, DateTimeKind.Local).AddTicks(1062));
=======
                        .HasDefaultValue(new DateTime(2021, 4, 27, 21, 10, 54, 554, DateTimeKind.Local).AddTicks(8036));
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0

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
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 498, DateTimeKind.Local).AddTicks(2603),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 573, DateTimeKind.Local).AddTicks(5583),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
                            Name = "Employee"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 498, DateTimeKind.Local).AddTicks(3994),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 573, DateTimeKind.Local).AddTicks(7954),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
                            Name = "Supervisor"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
<<<<<<< HEAD
                            CreatedAt = new DateTime(2021, 4, 29, 19, 39, 57, 498, DateTimeKind.Local).AddTicks(4028),
=======
                            CreatedAt = new DateTime(2021, 4, 27, 21, 10, 54, 573, DateTimeKind.Local).AddTicks(8322),
>>>>>>> c8147bc0636fa65d3e2b62125023f4127a9deee0
                            Name = "QualityBiomedical"
                        });
                });

            modelBuilder.Entity("NonComplianceNonComplianceRegister", b =>
                {
                    b.Property<int>("NonComplianceRegistersId")
                        .HasColumnType("integer");

                    b.Property<int>("NonCompliancesId")
                        .HasColumnType("integer");

                    b.HasKey("NonComplianceRegistersId", "NonCompliancesId");

                    b.HasIndex("NonCompliancesId");

                    b.ToTable("NonComplianceNonComplianceRegister");
                });

            modelBuilder.Entity("Domain.Entities.ActionPlainQuestion", b =>
                {
                    b.HasOne("Domain.Entities.ActionPlain", "ActionPlain")
                        .WithMany("Questions")
                        .HasForeignKey("ActionPlainId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ActionPlain");
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

                    b.Navigation("ActionPlain");

                    b.Navigation("ActionPlainQuestion");

                    b.Navigation("RootCauseAnalysis");
                });

            modelBuilder.Entity("Domain.Entities.NonCompliance", b =>
                {
                    b.HasOne("Domain.Entities.TypeNonCompliance", "TypeNonCompliance")
                        .WithMany("NonCompliances")
                        .HasForeignKey("TypeNonComplianceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TypeNonCompliance");
                });

            modelBuilder.Entity("Domain.Entities.NonComplianceRegister", b =>
                {
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

                    b.Navigation("Setor");

                    b.Navigation("User");
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

                    b.Navigation("ActionPlain");

                    b.Navigation("NonComplianceRegister");

                    b.Navigation("User");
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

                    b.Navigation("Setor");

                    b.Navigation("UserAuth");

                    b.Navigation("UserPermission");
                });

            modelBuilder.Entity("NonComplianceNonComplianceRegister", b =>
                {
                    b.HasOne("Domain.Entities.NonComplianceRegister", null)
                        .WithMany()
                        .HasForeignKey("NonComplianceRegistersId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.NonCompliance", null)
                        .WithMany()
                        .HasForeignKey("NonCompliancesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ActionPlain", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Responses");

                    b.Navigation("RootCauseAnalysis");
                });

            modelBuilder.Entity("Domain.Entities.ActionPlainQuestion", b =>
                {
                    b.Navigation("ActionPlainResponse");
                });

            modelBuilder.Entity("Domain.Entities.NonComplianceRegister", b =>
                {
                    b.Navigation("RootCauseAnalysis");
                });

            modelBuilder.Entity("Domain.Entities.RootCauseAnalysis", b =>
                {
                    b.Navigation("ActionPlainResponses");
                });

            modelBuilder.Entity("Domain.Entities.Setor", b =>
                {
                    b.Navigation("NonComplianceRegisters");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.TypeNonCompliance", b =>
                {
                    b.Navigation("NonCompliances");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("AnalyzeRootCauses");

                    b.Navigation("NonComplianceRegisters");
                });

            modelBuilder.Entity("Domain.Entities.UserAuth", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserPermission", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
