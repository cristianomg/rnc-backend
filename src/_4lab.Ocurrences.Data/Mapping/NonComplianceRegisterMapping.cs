using _4lab.Ocurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Ocurrences.Data.Mapping
{
    public class NonComplianceRegisterMapping : IEntityTypeConfiguration<NonComplianceRegister>
    {
        public void Configure(EntityTypeBuilder<NonComplianceRegister> builder)
        {
            builder.ToTable(nameof(NonComplianceRegister));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.ImmediateAction)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.MoreInformation)
                .HasMaxLength(255);

            builder.Property(x => x.PeopleInvolved)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.RegisterDate)
                .IsRequired();

            builder.Property(x => x.RegisterHour)
                .IsRequired();

            builder.HasMany(x => x.NonCompliances)
                .WithMany(x => x.NonComplianceRegisters)
                .UsingEntity(x => x.ToTable(nameof(NonComplianceNonComplianceRegister)));


            builder.HasOne(x => x.OccurrenceClassification)
                .WithMany(x => x.NonComplianceRegisters)
                .HasForeignKey(x => x.OccurrenceClassificationId);

            builder.Property(x => x.OcurrencePendency)
                .HasDefaultValue(null);

        }
    }
}
