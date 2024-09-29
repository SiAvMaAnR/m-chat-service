using Chat.Domain.Entities.Attachments;
using Chat.Persistence.DBContext;
using Chat.Persistence.Repositories.Common;

namespace Chat.Persistence.Repositories;

public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
{
    public AttachmentRepository(EFContext dbContext)
        : base(dbContext) { }
}
