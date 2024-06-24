using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using minimal_api.Domain.Common;

namespace minimal_api.Infrastructure.Mappings.Common;

public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IEntity<TEntity>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(_ => _.CreatedAt).IsRequired().HasColumnType("datetime");
        builder.Property(_ => _.UpdatedAt).HasColumnType("datetime").IsRequired(false);

        Map(builder);
    }

    protected abstract void Map(EntityTypeBuilder<TEntity> builder);
}
