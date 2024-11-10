﻿namespace Chat.WebApi.Controllers.Models.Channel;

public class ChannelControllerCreateDirectChannelRequest
{
    public int AccountId { get; set; }
    public int? AIProfileId { get; set; }
    public string? Name { get; set; }
}
