namespace Chat.Domain.Shared.Models;

public class AIMessage
{
    public required string Content { get; set; }
    public required string Role { get; set; }
}

public class AIRole
{
    public const string User = "user";
    public const string System = "system";
    public const string Assistant = "assistant";
}
