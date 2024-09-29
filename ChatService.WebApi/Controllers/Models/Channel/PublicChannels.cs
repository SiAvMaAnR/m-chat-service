using ChatService.Domain.Shared.Models;

namespace ChatService.WebApi.Controllers.Models.Channel;

public class ChannelControllerPublicChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
