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
    public class HowSatisfiedMapping : IEntityTypeConfiguration<HowSatisfied>
    {
        public void Configure(EntityTypeBuilder<HowSatisfied> builder)
        {
            builder.ToTable(nameof(HowSatisfied));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.HowSatisfiedUre)
                .IsRequired();

            builder.HasOne(x => x.SatisfactionSurvey)
                .WithOne(x => x.HowSatisfied)
                .HasForeignKey<SatisfactionSurvey>(x => x.HowSatisfiedId);
        }
    }
}
