﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _4lab.Occurrences.Data;

namespace _4Lab.Occurrences.Data.Migrations
{
    [DbContext(typeof(OccurrencesContext))]
    partial class OccurrencesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("OccurrenceOccurrenceRegister", b =>
                {
                    b.Property<Guid>("OccurrenceRegistersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OccurrencesId")
                        .HasColumnType("uuid");

                    b.HasKey("OccurrenceRegistersId", "OccurrencesId");

                    b.HasIndex("OccurrencesId");

                    b.ToTable("OccurrenceOccurrenceRegister");
                });

            modelBuilder.Entity("_4Lab.Core.Audit.Historic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Entity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Values")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Historic", "Audit", t => t.ExcludeFromMigrations());
                });

            modelBuilder.Entity("_4Lab.Occurrences.Domain.Models.VerificationOfEffectiveness", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("OccurrenceRegisterId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OccurrenceRegisterId")
                        .IsUnique();

                    b.ToTable("VerificationOfEffectiveness");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.ActionPlain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ActionPlain");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.ActionPlainQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionPlainId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("ActionPlainId");

                    b.ToTable("ActionPlainQuestion");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.ActionPlainResponse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionPlainId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionPlainQuestionId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RootCauseAnalysisId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

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

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.FiveWhat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RootCauseAnalysisId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("What")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RootCauseAnalysisId");

                    b.ToTable("FiveWhat");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.Occurrence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Occurrence");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.OccurrenceClassification", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OccurrenceClassification");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.OccurrenceRegister", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOcurrenceRisk")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CreatedRootCauseAnalysis")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CreatedVerificatoinOfEffectiveness")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ImmediateAction")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("MoreInformation")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int?>("OccurrenceClassificationId")
                        .HasColumnType("integer");

                    b.Property<int?>("OccurrencePendency")
                        .HasColumnType("integer");

                    b.Property<int?>("OccurrenceRiskId")
                        .HasColumnType("integer");

                    b.Property<int>("OccurrenceTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("PeopleInvolved")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RegisterHour")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SetorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OccurrenceClassificationId");

                    b.HasIndex("OccurrenceRiskId");

                    b.HasIndex("OccurrenceTypeId");

                    b.HasIndex("SetorId");

                    b.ToTable("OccurrenceRegister");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.OccurrenceRisk", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OccurrenceRisk");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.RootCauseAnalysis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActionPlainId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("OccurrenceRegisterId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ActionPlainId");

                    b.HasIndex("OccurrenceRegisterId")
                        .IsUnique();

                    b.ToTable("RootCauseAnalysis");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("SupervisorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Setor");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.TypeOccurrence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.None);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("OccurrenceTypeName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OccurrenceTypeName");

                    b.ToTable("TypeOccurrence");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2021, 10, 17, 12, 27, 7, 561, DateTimeKind.Local).AddTicks(7746),
                            IsDeleted = false,
                            OccurrenceTypeName = "De Processo"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 10, 17, 12, 27, 7, 564, DateTimeKind.Local).AddTicks(9222),
                            IsDeleted = false,
                            OccurrenceTypeName = "De Auditoria"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 10, 17, 12, 27, 7, 565, DateTimeKind.Local).AddTicks(517),
                            IsDeleted = false,
                            OccurrenceTypeName = "Reclamação de cliente"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedAt = new DateTime(2021, 10, 17, 12, 27, 7, 565, DateTimeKind.Local).AddTicks(1283),
                            IsDeleted = false,
                            OccurrenceTypeName = "De Indicador"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreatedAt = new DateTime(2021, 10, 17, 12, 27, 7, 565, DateTimeKind.Local).AddTicks(1930),
                            IsDeleted = false,
                            OccurrenceTypeName = "Análise de Risco"
                        });
                });

            modelBuilder.Entity("OccurrenceOccurrenceRegister", b =>
                {
                    b.HasOne("_4lab.Occurrences.Domain.Models.OccurrenceRegister", null)
                        .WithMany()
                        .HasForeignKey("OccurrenceRegistersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4lab.Occurrences.Domain.Models.Occurrence", null)
                        .WithMany()
                        .HasForeignKey("OccurrencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_4Lab.Occurrences.Domain.Models.VerificationOfEffectiveness", b =>
                {
                    b.HasOne("_4lab.Occurrences.Domain.Models.OccurrenceRegister", null)
                        .WithOne("VerificatoinOfEffectiveness")
                        .HasForeignKey("_4Lab.Occurrences.Domain.Models.VerificationOfEffectiveness", "OccurrenceRegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.ActionPlainQuestion", b =>
                {
                    b.HasOne("_4lab.Occurrences.Domain.Models.ActionPlain", "ActionPlain")
                        .WithMany("Questions")
                        .HasForeignKey("ActionPlainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionPlain");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.ActionPlainResponse", b =>
                {
                    b.HasOne("_4lab.Occurrences.Domain.Models.ActionPlain", "ActionPlain")
                        .WithMany("Responses")
                        .HasForeignKey("ActionPlainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4lab.Occurrences.Domain.Models.ActionPlainQuestion", "ActionPlainQuestion")
                        .WithMany("ActionPlainResponse")
                        .HasForeignKey("ActionPlainQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4lab.Occurrences.Domain.Models.RootCauseAnalysis", "RootCauseAnalysis")
                        .WithMany("ActionPlainResponses")
                        .HasForeignKey("RootCauseAnalysisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionPlain");

                    b.Navigation("ActionPlainQuestion");

                    b.Navigation("RootCauseAnalysis");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.FiveWhat", b =>
                {
                    b.HasOne("_4lab.Occurrences.Domain.Models.RootCauseAnalysis", "RootCauseAnalysis")
                        .WithMany("FiveWhats")
                        .HasForeignKey("RootCauseAnalysisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RootCauseAnalysis");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.OccurrenceRegister", b =>
                {
                    b.HasOne("_4lab.Occurrences.Domain.Models.OccurrenceClassification", "OccurrenceClassification")
                        .WithMany("OccurrenceRegisters")
                        .HasForeignKey("OccurrenceClassificationId");

                    b.HasOne("_4lab.Occurrences.Domain.Models.OccurrenceRisk", "OccurrenceRisk")
                        .WithMany("OccurrenceRegisters")
                        .HasForeignKey("OccurrenceRiskId");

                    b.HasOne("_4lab.Occurrences.Domain.Models.TypeOccurrence", "OccurrenceType")
                        .WithMany("OccurrenceRegisters")
                        .HasForeignKey("OccurrenceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4lab.Occurrences.Domain.Models.Setor", "Setor")
                        .WithMany("NonComplianceRegisters")
                        .HasForeignKey("SetorId");

                    b.Navigation("OccurrenceClassification");

                    b.Navigation("OccurrenceRisk");

                    b.Navigation("OccurrenceType");

                    b.Navigation("Setor");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.RootCauseAnalysis", b =>
                {
                    b.HasOne("_4lab.Occurrences.Domain.Models.ActionPlain", "ActionPlain")
                        .WithMany("RootCauseAnalysis")
                        .HasForeignKey("ActionPlainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_4lab.Occurrences.Domain.Models.OccurrenceRegister", "OccurrenceRegister")
                        .WithOne("RootCauseAnalysis")
                        .HasForeignKey("_4lab.Occurrences.Domain.Models.RootCauseAnalysis", "OccurrenceRegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionPlain");

                    b.Navigation("OccurrenceRegister");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.ActionPlain", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Responses");

                    b.Navigation("RootCauseAnalysis");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.ActionPlainQuestion", b =>
                {
                    b.Navigation("ActionPlainResponse");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.OccurrenceClassification", b =>
                {
                    b.Navigation("OccurrenceRegisters");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.OccurrenceRegister", b =>
                {
                    b.Navigation("RootCauseAnalysis");

                    b.Navigation("VerificatoinOfEffectiveness");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.OccurrenceRisk", b =>
                {
                    b.Navigation("OccurrenceRegisters");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.RootCauseAnalysis", b =>
                {
                    b.Navigation("ActionPlainResponses");

                    b.Navigation("FiveWhats");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.Setor", b =>
                {
                    b.Navigation("NonComplianceRegisters");
                });

            modelBuilder.Entity("_4lab.Occurrences.Domain.Models.TypeOccurrence", b =>
                {
                    b.Navigation("OccurrenceRegisters");
                });
#pragma warning restore 612, 618
        }
    }
}
