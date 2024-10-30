using Chat.Domain.Common;
using Chat.Infrastructure.RabbitMQ;
using Chat.Infrastructure.Services.AIService.Models;
using Chat.Infrastructure.Services.Common;

namespace Chat.Infrastructure.Services.AIService;

public class AIIS : BaseIService, IAIIS
{
    public AIIS(IAppSettings appSettings, IRabbitMQProducer rabbitMQProducer)
        : base(appSettings, rabbitMQProducer) { }

    public async Task<AIIServiceCreateMessageResponse?> CreateMessageAsync(
        AIIServiceCreateMessageRequest request
    )
    {
        RMQResponse<AIIServiceCreateMessageResponse>? response = await _rabbitMQProducer.Emit<
            RMQResponse<AIIServiceCreateMessageResponse>
        >(
            RMQ.Queue.Ai,
            RMQ.AIQueuePattern.CreateMessage,
            new { request.ProfileId, request.Messages }
        );

        return response?.Data;
    }
}
