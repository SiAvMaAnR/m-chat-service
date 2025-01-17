﻿namespace Chat.Application.Services.ChatService.Models;

public class ChatServiceSendMessageResponse
{
    public IEnumerable<string> UserIds { get; set; } = [];
    public required ChatServiceMessageResponseData Message { get; set; }
    public int? AIProfileId { get; set; } = null;
}
