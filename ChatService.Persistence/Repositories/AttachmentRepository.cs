using ChatService.Domain.Entities.Attachments;
using ChatService.Persistence.DBContext;
using ChatService.Persistence.Repositories.Common;

namespace ChatService.Persistence.Repositories;

public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
{
    public AttachmentRepository(EFContext dbContext)
        : base(dbContext) { }
}
