using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minimal_api.Domain.Entities;
using minimal_api.Infrastructure.Mappings.Common;

namespace minimal_api.Infrastructure.Mappings;

public class RoleMap : EntityMap<Role>
{
    protected override void Map(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Name).HasMaxLength(100).IsUnicode(false).IsRequired();
        builder.Property(_ => _.Description).HasMaxLength(255).IsUnicode(false);
    }
}
