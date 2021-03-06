using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Rnc.Mapping
{
    public class NaoConformidadeMapping : IEntityTypeConfiguration<NaoConformidade>
    {
        public void Configure(EntityTypeBuilder<NaoConformidade> builder)
        {
            builder.ToTable(nameof(NaoConformidade));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasOne(x => x.TipoNaoConformidade)
                .WithMany(x => x.NaoConformidades)
                .HasForeignKey(x => x.TipoNaoConformidadeId);
        }
    }
}
