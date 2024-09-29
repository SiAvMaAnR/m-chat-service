using ChatService.Domain.Entities;

namespace ChatService.Domain.Specification;

public class DefaultSpec<TEntity> : Specification<TEntity>
    where TEntity : BaseEntity
{
    public DefaultSpec()
    {
        ApplyTracking();
    }
}
