using ChatService.Infrastructure.Services.NotificationsService.Models;

namespace ChatService.Infrastructure.Services.NotificationsService;

public interface INotificationsIS
{
    Task<NotificationsIServiceSendEmailResponse> SendEmail(
        NotificationsIServiceSendEmailRequest request
    );
}
