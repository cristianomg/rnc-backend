using _4lab.Occurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Occurrences.Data.Mapping
{
    public class OccurrenceMapping : IEntityTypeConfiguration<Occurrence>
    {
        public void Configure(EntityTypeBuilder<Occurrence> builder)
        {
            builder.ToTable(nameof(Occurrence));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasMany(x => x.OccurrenceRegisters)
                .WithMany(x => x.Occurrences);
        }
    }
}
