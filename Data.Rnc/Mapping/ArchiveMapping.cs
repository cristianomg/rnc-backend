﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Rnc.Mapping
{
    public class ArchiveMapping : IEntityTypeConfiguration<Archive>
    {
        public void Configure(EntityTypeBuilder<Archive> builder)
        {
            builder.ToTable(nameof(Archive));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Key)
                .IsRequired();

            builder.HasOne(x => x.NonCompliance)
                .WithMany(x => x.Archives)
                .HasForeignKey(x => x.NonComplianceId)
                .IsRequired();

            builder.HasOne(x => x.NonComplianceRegister)
                .WithMany()
                .HasForeignKey(x => x.NonComplianceRegisterId)
                .IsRequired();

        }
    }
}
