using _4lab.Occurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Occurrences.Data.Mapping
{
    public class OccurrenceRegisterMapping : IEntityTypeConfiguration<OccurrenceRegister>
    {
        public void Configure(EntityTypeBuilder<OccurrenceRegister> builder)
        {
            builder.ToTable(nameof(OccurrenceRegister), "Occurrences");

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

            builder.HasMany(x => x.Occurrences)
                .WithMany(x => x.OccurrenceRegisters)
                .UsingEntity(x => x.ToTable(nameof(OccurrenceOccurrenceRegister)));


            builder.HasOne(x => x.OccurrenceClassification)
                .WithMany(x => x.OccurrenceRegisters)
                .HasForeignKey(x => x.OccurrenceClassificationId);

            builder.Property(x => x.OccurrencePendency)
                .HasDefaultValue(null);

        }
    }
}
