using Chat.Domain.Shared.Models;

namespace Chat.Infrastructure.Services.AIService.Models;

public class AIIServiceCreateMessageRequest
{
    public required int ProfileId { get; set; }
    public required IEnumerable<AIMessage> Messages { get; set; } = [];
}
