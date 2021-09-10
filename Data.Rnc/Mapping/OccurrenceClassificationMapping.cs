using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Rnc.Mapping
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
