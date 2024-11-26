namespace Chat.WebApi.RMQListeners.Chat;

public partial class ChatRMQService
{
    public class SendMessageData
    {
        public int? OriginalMessageId { get; set; }
        public required int ChannelId { get; set; }
        public required string Message { get; set; }
    }
}
