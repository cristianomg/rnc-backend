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
    public class TecnicalAreaMapping : IEntityTypeConfiguration<TecnicalArea>
    {
        public void Configure(EntityTypeBuilder<TecnicalArea> builder)
        {
            builder.ToTable(nameof(TecnicalArea));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.WaitingTime)
                .IsRequired();

            builder.Property(x => x.ProfissionalHability)
                .IsRequired();

            builder.Property(x => x.ExamOrientation)
                .IsRequired();

            builder.HasOne(x => x.SatisfactionSurvey)
                .WithOne(x => x.TecnicalArea)
                .HasForeignKey<SatisfactionSurvey>(x => x.TecnicalAreaId);
        }
    }
}
