using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Rnc.Mapping
{
    public class UserPermissionMapping : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable(nameof(UserPermission));

            builder.HasKey(x => x.Id);


            builder.HasMany(x => x.Users)
                .WithOne(x => x.UserPermission)
                .HasForeignKey(x => x.UserPermissionId);
        }
    }
}
