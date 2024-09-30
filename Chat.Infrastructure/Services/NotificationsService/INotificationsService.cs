using Chat.Infrastructure.Services.NotificationsService.Models;

namespace Chat.Infrastructure.Services.NotificationsService;

public interface INotificationsIS
{
    Task<NotificationsIServiceSendEmailResponse> SendEmailAsync(
        NotificationsIServiceSendEmailRequest request
    );
}
