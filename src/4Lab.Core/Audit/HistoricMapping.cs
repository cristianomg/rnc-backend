﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Lab.Core.Audit
{
    public class HistoricMapping : IEntityTypeConfiguration<Historic>
    {
        public void Configure(EntityTypeBuilder<Historic> builder)
        {
            builder.ToTable(nameof(Historic));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Entity)
                .IsRequired();

            builder.Property(x => x.Values)
                .IsRequired();
        }
    }
}
