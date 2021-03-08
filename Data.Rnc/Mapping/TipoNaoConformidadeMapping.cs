using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Rnc.Mapping
{
    public class TipoNaoConformidadeMapping : IEntityTypeConfiguration<TipoNaoConformidade>
    {
        public void Configure(EntityTypeBuilder<TipoNaoConformidade> builder)
        {
            builder.ToTable(nameof(TipoNaoConformidade));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.NomeTipoNaoConformidade)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(x => x.NomeTipoNaoConformidade)
                .IsUnique();

            builder.HasMany(x => x.NaoConformidades)
                .WithOne(x => x.TipoNaoConformidade)
                .HasForeignKey(x => x.TipoNaoConformidadeId);
        }
    }
}
