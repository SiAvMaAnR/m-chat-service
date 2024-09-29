using ChatService.Domain.Shared.Models;

namespace ChatService.Application.Services.ChannelService.Models;

public class ChannelServicePublicChannelsRequest
{
    public string? SearchField { get; set; }
    public Pagination? Pagination { get; set; }
}
