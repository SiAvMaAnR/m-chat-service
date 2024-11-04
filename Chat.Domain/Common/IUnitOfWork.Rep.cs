using Chat.Domain.Entities.Accounts;
using Chat.Domain.Entities.Accounts.Admins;
using Chat.Domain.Entities.Accounts.AIBots;
using Chat.Domain.Entities.Accounts.Users;
using Chat.Domain.Entities.Attachments;
using Chat.Domain.Entities.Channels;
using Chat.Domain.Entities.Messages;

namespace Chat.Domain.Common;

public partial interface IUnitOfWork
{
    IAccountRepository Account { get; }
    IUserRepository User { get; }
    IAdminRepository Admin { get; }
    IAIBotRepository AIBot { get; }
    IChannelRepository Channel { get; }
    IMessageRepository Message { get; }
    IAttachmentRepository Attachment { get; }
}
