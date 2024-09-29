using ChatService.Domain.Shared.Models;

namespace ChatService.Application.Services.ChannelService.Models;

public class ChannelServiceAccountChannelsRequest
{
    public string? SearchField { get; set; }
    public string? ChannelType { get; set; }
    public Pagination? Pagination { get; set; }
}
