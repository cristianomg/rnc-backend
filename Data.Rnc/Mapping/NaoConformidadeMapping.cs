using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Rnc.Mapping
{
    public class NaoConformidadeMapping : IEntityTypeConfiguration<NonCompliance>
    {
        public void Configure(EntityTypeBuilder<NonCompliance> builder)
        {
            builder.ToTable(nameof(NonCompliance));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(x => x.TypeNonCompliance)
                .WithMany(x => x.NonCompliances)
                .HasForeignKey(x => x.TypeNonComplianceId);
        }
    }
}
