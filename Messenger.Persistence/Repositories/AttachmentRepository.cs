using Messenger.Domain.Entities.Attachments;
using Messenger.Persistence.DBContext;
using Messenger.Persistence.Repositories.Common;

namespace Messenger.Persistence.Repositories;

public class AttachmentRepository : BaseRepository<Attachment>, IAttachmentRepository
{
    public AttachmentRepository(EFContext dbContext)
        : base(dbContext) { }
}
