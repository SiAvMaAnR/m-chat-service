using Chat.Domain.Entities.Messages;
using Chat.Domain.Exceptions;
using Chat.Domain.Shared.Constants.Common;
using Chat.Domain.Shared.Models;

namespace Chat.Application.Services.ChatService.Adapters;

public static class ChatServiceAIMessageAdapter
{
    public static IEnumerable<AIMessage> AdaptForAI(this IEnumerable<Message> messages)
    {
        return messages
            .Where(message => !string.IsNullOrEmpty(message.Text))
            .Select(
                message =>
                    new AIMessage()
                    {
                        Content = message.Text ?? "",
                        Role = message.Author?.Role switch
                        {
                            AccountRole.User => AIRole.User,
                            AccountRole.Admin => AIRole.User,
                            AccountRole.AIBot => AIRole.Assistant,
                            _ => throw new IncorrectDataException("Account role is incorrect")
                        }
                    }
            );
    }
}
