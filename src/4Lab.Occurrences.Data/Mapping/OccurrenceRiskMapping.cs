using _4lab.Occurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Occurrences.Data.Mapping
{
    public class OccurrenceRiskMapping : IEntityTypeConfiguration<OccurrenceRisk>
    {
        public void Configure(EntityTypeBuilder<OccurrenceRisk> builder)
        {
            builder.ToTable(nameof(OccurrenceRisk));

            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.OccurrenceRegisters)
                .WithOne(x => x.OccurrenceRisk)
                .HasForeignKey(x => x.OccurrenceRiskId);

        }
    }
}
