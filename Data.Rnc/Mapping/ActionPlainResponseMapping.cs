using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Rnc.Mapping
{
    public class ActionPlainResponseMapping : IEntityTypeConfiguration<ActionPlainResponse>
    {
        public void Configure(EntityTypeBuilder<ActionPlainResponse> builder)
        {
            builder.ToTable(nameof(ActionPlainResponse));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Value).IsRequired().HasMaxLength(255);

            builder.HasOne(x => x.ActionPlainQuestion)
                .WithMany(x => x.ActionPlainResponse)
                .HasForeignKey(x => x.ActionPlainQuestionId);

            builder.HasOne(x => x.RootCauseAnalysis)
                .WithMany(x => x.ActionPlainResponses)
                .HasForeignKey(x => x.RootCauseAnalysisId);
        }
    }
}
