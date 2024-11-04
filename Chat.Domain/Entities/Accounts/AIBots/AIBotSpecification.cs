using Chat.Domain.Specification;

namespace Chat.Domain.Entities.Accounts.AIBots;

public class FirstAIBotSpec : Specification<AIBot>
{
    public FirstAIBotSpec()
    {
        ApplyTracking();
    }
}
