using Chat.Infrastructure.Services.AIService.Models;

namespace Chat.Infrastructure.Services.AIService;

public interface IAIIS
{
    Task<AIIServiceCreateMessageResponse?> CreateMessageAsync(
        AIIServiceCreateMessageRequest request
    );
}
