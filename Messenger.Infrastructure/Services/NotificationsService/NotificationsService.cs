using Messenger.Domain.Common;
using Messenger.Infrastructure.RabbitMQ;
using Messenger.Infrastructure.Services.Common;
using Messenger.Infrastructure.Services.NotificationsService.Models;

namespace Messenger.Infrastructure.Services.NotificationsService;

public class NotificationsIS : BaseIService, INotificationsIS
{
    public NotificationsIS(IAppSettings appSettings, IRabbitMQProducer rabbitMQProducer)
        : base(appSettings, rabbitMQProducer) { }

    public async Task<NotificationsIServiceSendEmailResponse> SendEmail(
        NotificationsIServiceSendEmailRequest request
    )
    {
        _rabbitMQProducer.Send(
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
