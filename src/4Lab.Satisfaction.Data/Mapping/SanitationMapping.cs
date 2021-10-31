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
    public class SanitationMapping : IEntityTypeConfiguration<Sanitation>
    {
        public void Configure(EntityTypeBuilder<Sanitation> builder)
        {
            builder.ToTable(nameof(Sanitation));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LocalSanitation)
                .IsRequired();

            builder.HasOne(x => x.SatisfactionSurvey)
                .WithOne(x => x.Sanitation)
                .HasForeignKey<SatisfactionSurvey>(x => x.SanitationId);

        }
    }
}
