using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Rnc.Mapping
{
    public class NonComplianceRegisterMapping : IEntityTypeConfiguration<NonComplianceRegister>
    {
        public void Configure(EntityTypeBuilder<NonComplianceRegister> builder)
        {
            builder.ToTable(nameof(NonComplianceRegister));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.NonComplianceId)
                .IsRequired();

            builder.Property(x => x.ImmediateAction)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(x => x.MoreInformation)
                .HasMaxLength(255);
            
            builder.Property(x => x.PeopleInvolved)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.RegisterDate)
                .IsRequired();

            builder.Property(x => x.RegisterHour)
                .IsRequired();

            builder.Property(x => x.Setor)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.User)
                .WithMany(x => x.NonComplianceRegisters)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.NonCompliance)
                .WithMany(x => x.NonCompliceRegisters)
                .HasForeignKey(x => x.NonComplianceId);
        }
    }
}
