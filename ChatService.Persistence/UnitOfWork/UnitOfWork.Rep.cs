using ChatService.Domain.Entities.Accounts;
using ChatService.Domain.Entities.Admins;
using ChatService.Domain.Entities.Attachments;
using ChatService.Domain.Entities.Channels;
using ChatService.Domain.Entities.Messages;
using ChatService.Domain.Entities.RefreshTokens;
using ChatService.Domain.Entities.Users;
using ChatService.Persistence.DBContext;
using ChatService.Persistence.Repositories;

namespace ChatService.Persistence.UnitOfWork;

public partial class UnitOfWork(EFContext eFContext)
{
    private readonly EFContext _eFContext = eFContext;

    public IUserRepository User { get; } = new UserRepository(eFContext);
    public IAccountRepository Account { get; } = new AccountRepository(eFContext);
    public IAdminRepository Admin { get; } = new AdminRepository(eFContext);
    public IRefreshTokenRepository RefreshToken { get; } = new RefreshTokenRepository(eFContext);
    public IMessageRepository Message { get; } = new MessageRepository(eFContext);
    public IChannelRepository Channel { get; } = new ChannelRepository(eFContext);
    public IAttachmentRepository Attachment { get; } = new AttachmentRepository(eFContext);
}
