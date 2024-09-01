using Messenger.Infrastructure.Services.NotificationsService.Models;

namespace Messenger.Infrastructure.Services.NotificationsService;

public interface INotificationsIS
{
    Task<NotificationsIServiceSendEmailResponse> SendEmail(
        NotificationsIServiceSendEmailRequest request
    );
}
