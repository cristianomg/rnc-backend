using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Rnc.Mapping
{
    public class AnalyzeRootCauseMapping : IEntityTypeConfiguration<RootCauseAnalysis>
    {
        public void Configure(EntityTypeBuilder<RootCauseAnalysis> builder)
        {
            builder.ToTable(nameof(RootCauseAnalysis));

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Analyze).IsRequired();

            builder.Property(x => x.NonComplianceRegisterId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.AnalyzeRootCauses)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.NonComplianceRegister)
                .WithOne(x => x.RootCauseAnalysis)
                .HasForeignKey<RootCauseAnalysis>(x => x.NonComplianceRegisterId);
        }
    }
}
