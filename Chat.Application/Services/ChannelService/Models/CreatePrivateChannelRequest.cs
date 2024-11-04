namespace Chat.Application.Services.ChannelService.Models;

public class ChannelServiceCreatePrivateChannelRequest
{
    public required string Name { get; set; }
    public IEnumerable<int> Members { get; set; } = [];
    public int? AIProfileId { get; set; }
}
