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
    public class PersonalInformationsMapping : IEntityTypeConfiguration<PersonalInformations>
    {
        public void Configure(EntityTypeBuilder<PersonalInformations> builder)
        {
            builder.ToTable(nameof(PersonalInformations));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.HasOne(x => x.SatisfactionSurvey)
                .WithOne(x => x.PersonalInformations)
                .HasForeignKey<SatisfactionSurvey>(x => x.PersonalInformationsId);


        }
    }
}
