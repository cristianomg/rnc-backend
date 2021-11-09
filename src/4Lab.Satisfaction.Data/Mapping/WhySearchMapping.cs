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
    public class WhySearchMapping : IEntityTypeConfiguration<WhySearch>
    {
        public void Configure(EntityTypeBuilder<WhySearch> builder)
        {
            builder.ToTable(nameof(WhySearch));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ResearchQuestions)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.HasOne(x => x.SatisfactionSurvey)
                .WithMany(x => x.WhySearch)
                .HasForeignKey(x => x.SatisfactionSurveyId);
        }
    }
}
