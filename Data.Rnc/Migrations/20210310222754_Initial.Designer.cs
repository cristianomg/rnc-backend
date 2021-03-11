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
    [Migration("20210310222754_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(7317),
                            Descricao = "Erros de cadastro do paciente ou médico.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(8696),
                            Descricao = "Requisições ilegíveis.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(8751),
                            Descricao = "Paciente com preparo inadequado.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(8773),
                            Descricao = "Incidente com cliente.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(8794),
                            Descricao = "Amostra insuficiente.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(8820),
                            Descricao = "Tubo inadequado.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(8841),
                            Descricao = "Amostra com identificação errada ou incompleta.",
                            TipoNaoConformidadeId = 1
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(8862),
                            Descricao = "Material não tirado da pendência.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 9,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(8884),
                            Descricao = "Equipamento em manutenção.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 10,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(8906),
                            Descricao = "Perda de amostra.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 11,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(8927),
                            Descricao = "Material fora da validade.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 12,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(9076),
                            Descricao = "Centrifugação incorreta.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 13,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(9100),
                            Descricao = "Queda de energia.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 14,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(9121),
                            Descricao = "Armazenamento errado da amostra.",
                            TipoNaoConformidadeId = 2
                        },
                        new
                        {
                            Id = 15,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(9142),
                            Descricao = "Erro de digitação dos laudos: resultados trocados, incoerente ou falta de resultados.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 16,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(9163),
                            Descricao = "Laudos entregues trocados.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 17,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(9183),
                            Descricao = "Atraso na liberação do laudo.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 18,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(9206),
                            Descricao = "Falta da assinatura do Biomédico no laudo.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 19,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(9227),
                            Descricao = "Erro de transcrição de resultado na ficha de bancada.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 20,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(9248),
                            Descricao = "Questionamento do resultado feito pelo médico ou cliente.",
                            TipoNaoConformidadeId = 3
                        },
                        new
                        {
                            Id = 21,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(9268),
                            Descricao = "Perda do laudo.",
                            TipoNaoConformidadeId = 3
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

                    b.ToTable("TipoNaoConformidade");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(4199),
                            NomeTipoNaoConformidade = "Pre-Analitica"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(6555),
                            NomeTipoNaoConformidade = "Analitica"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(6626),
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

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2021, 3, 10, 19, 27, 53, 567, DateTimeKind.Local).AddTicks(8962));

                    b.Property<string>("Enrollment")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserAuthId")
                        .HasColumnType("integer");

                    b.Property<int>("UserPermissionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Enrollment")
                        .IsUnique();

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
                        .HasDefaultValue(new DateTime(2021, 3, 10, 19, 27, 53, 559, DateTimeKind.Local).AddTicks(3381));

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
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 580, DateTimeKind.Local).AddTicks(8508),
                            Name = "Employee"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(990),
                            Name = "Supervisor"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreatedAt = new DateTime(2021, 3, 10, 19, 27, 53, 581, DateTimeKind.Local).AddTicks(1151),
                            Name = "QualityBiomedical"
                        });
                });

            modelBuilder.Entity("Domain.Entities.NaoConformidade", b =>
                {
                    b.HasOne("Domain.Entities.TipoNaoConformidade", "TipoNaoConformidade")
                        .WithMany("NaoConformidades")
                        .HasForeignKey("TipoNaoConformidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.UserAuth", "UserAuth")
                        .WithOne("User")
                        .HasForeignKey("Domain.Entities.User", "UserAuthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UserPermission", "UserPermission")
                        .WithMany("Users")
                        .HasForeignKey("UserPermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
