using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Rnc.Mapping
{
    public class ListArchivesMapping : IEntityTypeConfiguration<Archives>
    {
        public void Configure(EntityTypeBuilder<Archives> builder)
        {
            builder.ToTable(nameof(Archives));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.URL)
                .IsRequired();

            builder.HasOne(x => x.NonComplimance)
                .WithMany(x => x.Archives)
                .HasForeignKey(x => x.Id);
                
        }
    }
}
