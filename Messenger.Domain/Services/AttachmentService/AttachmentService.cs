using Messenger.Domain.Common;
using Messenger.Domain.Entities.Attachments;

namespace Messenger.Domain.Services;

public class AttachmentBS : DomainService
{
    public AttachmentBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<Attachment?> GetAttachmentByUniqueIdAsync(string uniqueId)
    {
        return await _unitOfWork.Attachment.GetAsync(new AttachmentByUniqueIdSpec(uniqueId));
    }

    public async Task<Attachment?> GetAttachmentByIdAsync(int id)
    {
        return await _unitOfWork.Attachment.GetAsync(new AttachmentByIdSpec(id));
    }

    public async Task<IEnumerable<Attachment>> GetPreviewAttachmentsAsync(
        int channelId,
        int ownerId
    )
    {
        return await _unitOfWork
            .Attachment
            .GetAllAsync(new PreviewAttachmentsSpec(channelId, ownerId));
    }

    public async Task CreateAttachmentAsync(Attachment attachment)
    {
        await _unitOfWork.Attachment.AddAsync(attachment);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveAttachmentAsync(Attachment attachment)
    {
        _unitOfWork.Attachment.Delete(attachment);
        await _unitOfWork.SaveChangesAsync();
    }
}
