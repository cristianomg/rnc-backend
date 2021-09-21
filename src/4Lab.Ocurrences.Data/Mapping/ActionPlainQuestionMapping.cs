using _4lab.Occurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Occurrences.Data.Mapping
{
    public class ActionPlainQuestionMapping : IEntityTypeConfiguration<ActionPlainQuestion>
    {
        public void Configure(EntityTypeBuilder<ActionPlainQuestion> builder)
        {
            builder.ToTable(nameof(ActionPlainQuestion), "Occurrences");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Value).IsRequired().HasMaxLength(255);

            builder.HasOne(x => x.ActionPlain)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.ActionPlainId);

            builder.HasMany(x => x.ActionPlainResponse)
                .WithOne(x => x.ActionPlainQuestion)
                .HasForeignKey(x => x.ActionPlainQuestionId);
        }
    }
}
