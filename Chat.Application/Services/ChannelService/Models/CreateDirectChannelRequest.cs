namespace Chat.Application.Services.ChannelService.Models;

public class ChannelServiceCreateDirectChannelRequest
{
    public int AccountId { get; set; }
    public string? Name { get; set; }
    public int? AIProfileId { get; set; }
}
