using Chat.Infrastructure.Services.AIService.Models;

namespace Chat.Infrastructure.Services.AIService;

public interface IAIIS
{
    void CreateMessage(AIIServiceCreateMessageRequest request);
}
