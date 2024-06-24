using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minimal_api.Domain.Entities;
using minimal_api.Infrastructure.Mappings.Common;

namespace minimal_api.Infrastructure.Mappings;

public class UserMap : EntityMap<User>
{
    protected override void Map(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Username).HasMaxLength(128).IsUnicode(false).IsRequired();
        builder.Property(_ => _.PasswordHash).HasMaxLength(255).IsUnicode(false).IsRequired();
        builder.Property(_ => _.Email).HasMaxLength(255).IsUnicode(false).IsRequired();
        builder.HasOne(_ => _.Role).WithMany(r => r.Users).HasForeignKey(r => r.RoleId);

        builder.HasIndex(_ => _.Email).IsUnique();
    }
}
