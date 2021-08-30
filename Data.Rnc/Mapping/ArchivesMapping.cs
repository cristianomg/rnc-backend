using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Rnc.Mapping
{
    public class ArchivesMapping : IEntityTypeConfiguration<Archives>
    {
        public void Configure(EntityTypeBuilder<Archives> builder)
        {
            builder.ToTable(nameof(Archives));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.NonComplimance)
                .WithMany(x => x.Archives)
                .HasForeignKey(x => x.Id);

        }
    }
}
