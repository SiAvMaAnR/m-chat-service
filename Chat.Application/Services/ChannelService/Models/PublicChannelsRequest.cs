using Chat.Domain.Shared.Models;

namespace Chat.Application.Services.ChannelService.Models;

public class ChannelServicePublicChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
