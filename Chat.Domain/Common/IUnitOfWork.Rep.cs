using Chat.Domain.Entities.Accounts;
using Chat.Domain.Entities.Admins;
using Chat.Domain.Entities.Attachments;
using Chat.Domain.Entities.Channels;
using Chat.Domain.Entities.Messages;
using Chat.Domain.Entities.RefreshTokens;
using Chat.Domain.Entities.Users;

namespace Chat.Domain.Common;

public partial interface IUnitOfWork
{
    IAccountRepository Account { get; }
    IUserRepository User { get; }
    IAdminRepository Admin { get; }
    IRefreshTokenRepository RefreshToken { get; }
    IChannelRepository Channel { get; }
    IMessageRepository Message { get; }
    IAttachmentRepository Attachment { get; }
}
