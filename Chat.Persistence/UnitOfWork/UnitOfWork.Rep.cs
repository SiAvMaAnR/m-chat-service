using Chat.Domain.Entities.Accounts;
using Chat.Domain.Entities.Accounts.Admins;
using Chat.Domain.Entities.Accounts.AIBots;
using Chat.Domain.Entities.Accounts.Users;
using Chat.Domain.Entities.Attachments;
using Chat.Domain.Entities.Channels;
using Chat.Domain.Entities.Messages;
using Chat.Persistence.DBContext;
using Chat.Persistence.Repositories;

namespace Chat.Persistence.UnitOfWork;

public partial class UnitOfWork(EFContext eFContext)
{
    private readonly EFContext _eFContext = eFContext;

    public IAccountRepository Account { get; } = new AccountRepository(eFContext);
    public IUserRepository User { get; } = new UserRepository(eFContext);
    public IAdminRepository Admin { get; } = new AdminRepository(eFContext);
    public IAIBotRepository AIBot { get; } = new AIBotRepository(eFContext);
    public IMessageRepository Message { get; } = new MessageRepository(eFContext);
    public IChannelRepository Channel { get; } = new ChannelRepository(eFContext);
    public IAttachmentRepository Attachment { get; } = new AttachmentRepository(eFContext);
}
