namespace Chat.Domain.Entities;

public interface ISoftDelete
{
    bool IsDeleted { get; }
    void Delete();
}
