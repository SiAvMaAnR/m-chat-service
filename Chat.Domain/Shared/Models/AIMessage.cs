namespace Chat.Domain.Shared.Models;

public class AIMessage
{
    public required string Content { get; set; }
    public required string Role { get; set; }
}
