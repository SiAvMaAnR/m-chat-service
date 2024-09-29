using ChatService.Domain.Shared.Models;

namespace ChatService.WebApi.Controllers.Models.Channel;

public class ChannelControllerAccountChannelsRequest
{
    public string? SearchField { get; set; }
    public string? ChannelType { get; set; }
    public Pagination? Pagination { get; set; }
}
