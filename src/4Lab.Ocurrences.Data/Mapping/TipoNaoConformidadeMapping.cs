using _4lab.Ocurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Ocurrences.Data.Mapping
{
    public class TipoNaoConformidadeMapping : IEntityTypeConfiguration<TypeNonCompliance>
    {
        public void Configure(EntityTypeBuilder<TypeNonCompliance> builder)
        {
            builder.ToTable(nameof(TypeNonCompliance));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.NameNonCompliance)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(x => x.NameNonCompliance)
                .IsUnique();

            builder.HasMany(x => x.NonCompliances)
                .WithOne(x => x.TypeNonCompliance)
                .HasForeignKey(x => x.TypeNonComplianceId);
        }
    }
}
