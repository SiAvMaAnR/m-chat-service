using Chat.Domain.Entities;

namespace Chat.Domain.Specification;

public class DefaultSpec<TEntity> : Specification<TEntity>
    where TEntity : BaseEntity
{
    public DefaultSpec()
    {
        ApplyTracking();
    }
}
