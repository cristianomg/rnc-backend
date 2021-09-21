using _4lab.Ocurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Ocurrences.Data.Mapping
{
    public class OccurrenceClassificationMapping : IEntityTypeConfiguration<OccurrenceClassification>
    {
        public void Configure(EntityTypeBuilder<OccurrenceClassification> builder)
        {
            builder.ToTable(nameof(OccurrenceClassification));

            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.NonComplianceRegisters)
                .WithOne(x => x.OccurrenceClassification)
                .HasForeignKey(x => x.OccurrenceClassificationId);

        }
    }
}
