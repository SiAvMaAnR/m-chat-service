using ChatService.Domain.Entities.Accounts;
using ChatService.Domain.Entities.Admins;
using ChatService.Domain.Entities.Attachments;
using ChatService.Domain.Entities.Channels;
using ChatService.Domain.Entities.Messages;
using ChatService.Domain.Entities.RefreshTokens;
using ChatService.Domain.Entities.Users;

namespace ChatService.Domain.Common;

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
