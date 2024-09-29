namespace ChatService.Domain.Entities;

public interface ISoftDelete
{
    bool IsDeleted { get; }
}
