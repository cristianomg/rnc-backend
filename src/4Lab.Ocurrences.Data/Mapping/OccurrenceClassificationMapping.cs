using _4lab.Occurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Occurrences.Data.Mapping
{
    public class OccurrenceClassificationMapping : IEntityTypeConfiguration<OccurrenceClassification>
    {
        public void Configure(EntityTypeBuilder<OccurrenceClassification> builder)
        {
            builder.ToTable(nameof(OccurrenceClassification), "Occurrences");

            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.OccurrenceRegisters)
                .WithOne(x => x.OccurrenceClassification)
                .HasForeignKey(x => x.OccurrenceClassificationId);

        }
    }
}
