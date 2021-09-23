using _4lab.Occurrences.Domain.Models;
using _4Lab.Core.DomainObjects.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Occurrences.Data.Mapping
{
    public class OccurrenceTypeMapping : IEntityTypeConfiguration<TypeOccurrence>
    {
        public void Configure(EntityTypeBuilder<TypeOccurrence> builder)
        {
            builder.ToTable(nameof(TypeOccurrence));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.OccurrenceTypeName)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(x => x.OccurrenceTypeName);

            builder.HasMany(x => x.Occurrences)
                .WithOne(x => x.OccurrenceType)
                .HasForeignKey(x => x.OccurrenceTypeId);
        }
    }
}
