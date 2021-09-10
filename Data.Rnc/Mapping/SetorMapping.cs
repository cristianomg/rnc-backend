using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Rnc.Mapping
{
    public class SetorMapping : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.ToTable(nameof(Setor));

            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.Users)
                .WithOne(x => x.Setor)
                .HasForeignKey(x => x.SetorId);

            builder.HasOne(x => x.ResponsavelDoSetor)
                .WithMany(x => x.SetoresSupervisao)
                .HasForeignKey(x => x.ResponsavelDoSetorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
