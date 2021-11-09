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
    public class DeliveryResultsMapping : IEntityTypeConfiguration<DeliveryResults>
    {
        public void Configure(EntityTypeBuilder<DeliveryResults> builder)
        {
            builder.ToTable(nameof(DeliveryResults));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.DeliveryResultTime)
                .IsRequired();

            builder.Property(x => x.DeliveryPunctuality)
                .IsRequired();

            builder.HasOne(x => x.SatisfactionSurvey)
                .WithOne(x => x.DeliveryResults)
                .HasForeignKey<SatisfactionSurvey>(x => x.DeliveryResultsId);
        }
    }
}
