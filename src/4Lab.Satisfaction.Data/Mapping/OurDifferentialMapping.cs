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
    public class OurDifferentialMapping : IEntityTypeConfiguration<OurDifferential>
    {
        public void Configure(EntityTypeBuilder<OurDifferential> builder)
        {
            builder.ToTable(nameof(OurDifferential));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.HasOne(x => x.SatisfactionSurvey)
                .WithMany(x => x.OurDifferential)
                .HasForeignKey(x => x.SatisfactionSurveyId);
                
        }
    }
}
