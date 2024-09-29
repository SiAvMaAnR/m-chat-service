using Chat.Domain.Shared.Models;

namespace Chat.Application.Services.ChannelService.Models;

public class ChannelServiceAccountChannelsRequest
{
    public string? SearchField { get; set; }
    public string? ChannelType { get; set; }
    public Pagination? Pagination { get; set; }
}
