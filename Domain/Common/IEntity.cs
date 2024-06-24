namespace minimal_api.Domain.Common;

public interface IEntity<in TEntity> : IAudit
{
    bool IsPersisted();
}
