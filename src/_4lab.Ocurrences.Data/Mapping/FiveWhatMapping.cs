using _4lab.Ocurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Ocurrences.Data.Mapping
{
    public class FiveWhatMapping : IEntityTypeConfiguration<FiveWhat>
    {
        public void Configure(EntityTypeBuilder<FiveWhat> builder)
        {
            builder.ToTable(nameof(FiveWhat));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.RootCauseAnalysis)
                .WithMany(x => x.FiveWhats)
                .HasForeignKey(x => x.RootCauseAnalysisId);

        }
    }
}