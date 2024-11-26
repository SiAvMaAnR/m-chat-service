namespace Chat.WebApi.Controllers.Models.Channel;

public class ChannelControllerCreateDirectChannelRequest
{
    public string? Name { get; set; }
    public int AccountId { get; set; }
    public int? AIProfileId { get; set; }
}
