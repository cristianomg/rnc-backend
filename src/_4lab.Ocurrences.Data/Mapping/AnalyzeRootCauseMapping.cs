using _4lab.Ocurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Ocurrences.Data.Mapping
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

            builder.Property(x => x.NonComplianceRegisterId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.NonComplianceRegister)
                .WithOne(x => x.RootCauseAnalysis)
                .HasForeignKey<RootCauseAnalysis>(x => x.NonComplianceRegisterId);

            builder.HasOne(x => x.ActionPlain)
                .WithMany(x => x.RootCauseAnalysis)
                .HasForeignKey(x => x.ActionPlainId);
        }
    }
}
