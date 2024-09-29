using Chat.Domain.Shared.Models;

namespace Chat.WebApi.Controllers.Models.Channel;

public class ChannelControllerPublicChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
