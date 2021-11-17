using _4Lab.Administration.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace _4lab.Administration.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Enrollment)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(x => x.Enrollment)
                .IsUnique();

            builder.Property(x => x.Active)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.UserAuthId)
                .IsRequired();

            builder.HasOne(x => x.UserAuth)
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.UserAuthId);

            builder.HasOne(x => x.UserPermission)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.UserPermissionId);
        }
    }
}
