namespace Chat.WebApi.RMQListeners.AI;

public partial class AIRMQService
{
    public class SendMessageData
    {
        public required int ChannelId { get; set; }
        public required string Message { get; set; }
    }
}
