using _4Lab.Satisfaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Lab.Satisfaction.Data.Mapping
{
    public class OverallImpressionMapping : IEntityTypeConfiguration<OverallImpression>
    {
        public void Configure(EntityTypeBuilder<OverallImpression> builder)
        {
            builder.ToTable(nameof(OverallImpression));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FriendsRecommendation)
                .IsRequired();

            builder.HasOne(x => x.SatisfactionSurvey)
                .WithOne(x => x.OverallImpression)
                .HasForeignKey<SatisfactionSurvey>(x => x.OverallImpressionId);
        }
    }
}
