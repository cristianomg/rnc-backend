using _4lab.Ocurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Ocurrences.Data.Mapping
{
    public class NaoConformidadeMapping : IEntityTypeConfiguration<NonCompliance>
    {
        public void Configure(EntityTypeBuilder<NonCompliance> builder)
        {
            builder.ToTable(nameof(NonCompliance));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(x => x.TypeNonCompliance)
                .WithMany(x => x.NonCompliances)
                .HasForeignKey(x => x.TypeNonComplianceId);

            builder.HasMany(x => x.NonComplianceRegisters)
                .WithMany(x => x.NonCompliances)
                .UsingEntity(x => x.ToTable(nameof(NonComplianceNonComplianceRegister)));
        }
    }
}
