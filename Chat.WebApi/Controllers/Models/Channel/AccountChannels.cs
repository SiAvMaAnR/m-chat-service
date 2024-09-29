using Chat.Domain.Shared.Models;

namespace Chat.WebApi.Controllers.Models.Channel;

public class ChannelControllerAccountChannelsRequest
{
    public string? SearchField { get; set; }
    public string? ChannelType { get; set; }
    public Pagination? Pagination { get; set; }
}
