using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Rnc.Mapping
{
    public class SetorMapping : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.ToTable(nameof(Setor));

            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.Users)
                .WithOne(x => x.Setor)
                .HasForeignKey(x => x.SetorId);
        }
    }
}
