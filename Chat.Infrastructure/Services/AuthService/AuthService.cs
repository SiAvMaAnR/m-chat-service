using Chat.Domain.Common;
using Chat.Infrastructure.RabbitMQ;
using Chat.Infrastructure.Services.AuthService.Models;
using Chat.Infrastructure.Services.Common;

namespace Chat.Infrastructure.Services.NotificationsService;

public class AuthIS : BaseIService, IAuthIS
{
    public AuthIS(IAppSettings appSettings, IRabbitMQProducer rabbitMQProducer)
        : base(appSettings, rabbitMQProducer) { }

    public async Task<AuthIServiceLoginResponse?> LoginAsync(AuthIServiceLoginRequest request)
    {
        RMQResponse<AuthIServiceLoginResponse>? response = await _rabbitMQProducer.Emit<
            RMQResponse<AuthIServiceLoginResponse>
        >(RMQ.Queue.Auth, RMQ.AuthQueuePattern.Login, new { request.Email, request.Password });

        return response?.Data;
    }
}
