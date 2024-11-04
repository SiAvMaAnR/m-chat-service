using Chat.Domain.Common;
using Chat.Infrastructure.RabbitMQ;
using Chat.Infrastructure.Services.Common;
using Chat.Infrastructure.Services.NotificationsService.Models;

namespace Chat.Infrastructure.Services.NotificationsService;

public class NotificationsIS : BaseIService, INotificationsIS
{
    public NotificationsIS(IAppSettings appSettings, IRabbitMQProducer rabbitMQProducer)
        : base(appSettings, rabbitMQProducer) { }

    public async Task<NotificationsIServiceSendEmailResponse> SendEmailAsync(
        NotificationsIServiceSendEmailRequest request
    )
    {
        _rabbitMQProducer.Emit(
            RMQ.Queue.Notifications,
            RMQ.NotificationsQueuePattern.SendEmail,
            new
            {
                emailTemplate = request.Template,
                recipient = request.Recipient,
                data = request.Data
            }
        );

        return await Task.FromResult(
            new NotificationsIServiceSendEmailResponse() { IsSuccess = true }
        );
    }
}

public static class EmailTemplate
{
    public const string ConfirmRegistration = "confirm-registration";
    public const string ResetPassword = "reset-password";
}
