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
    public class ReceptionMapping : IEntityTypeConfiguration<Reception>
    {
        public void Configure(EntityTypeBuilder<Reception> builder)
        {
            builder.ToTable(nameof(Reception));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.WaitingTime)
                .IsRequired();

            builder.Property(x => x.AttendanceAgility)
                .IsRequired();

            builder.HasOne(x => x.SatisfactionSurvey)
                .WithOne(x => x.Reception)
                .HasForeignKey<SatisfactionSurvey>(x => x.ReceptionId);
        }
    }
}
