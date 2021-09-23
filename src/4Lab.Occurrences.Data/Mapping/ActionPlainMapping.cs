using _4lab.Occurrences.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4lab.Occurrences.Data.Mapping
{
    public class ActionPlainMapping : IEntityTypeConfiguration<ActionPlain>
    {
        public void Configure(EntityTypeBuilder<ActionPlain> builder)
        {
            builder.ToTable(nameof(ActionPlain));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired().HasMaxLength(50);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.ActionPlain)
                .HasForeignKey(x => x.ActionPlainId);

            builder.HasMany(x => x.RootCauseAnalysis)
                .WithOne(x => x.ActionPlain)
                .HasForeignKey(x => x.ActionPlainId);
        }
    }
}
