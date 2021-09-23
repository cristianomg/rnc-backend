using _4lab.Occurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Occurrences.Data.Mapping
{
    public class AnalyzeRootCauseMapping : IEntityTypeConfiguration<RootCauseAnalysis>
    {
        public void Configure(EntityTypeBuilder<RootCauseAnalysis> builder)
        {
            builder.ToTable(nameof(RootCauseAnalysis));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.OccurrenceRegisterId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.OccurrenceRegister)
                .WithOne(x => x.RootCauseAnalysis)
                .HasForeignKey<RootCauseAnalysis>(x => x.OccurrenceRegisterId);

            builder.HasOne(x => x.ActionPlain)
                .WithMany(x => x.RootCauseAnalysis)
                .HasForeignKey(x => x.ActionPlainId);
        }
    }
}
