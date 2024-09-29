﻿using ChatService.Application.Services.ChatService.Models;
using ChatService.Domain.Entities.Messages;

namespace ChatService.Application.Services.ChatService.Adapters;

public class ChatServiceMessageAdapter : ChatServiceMessageResponseData
{
    public ChatServiceMessageAdapter(Message message)
    {
        Id = message.Id;
        Text = message.Text;
        ModifiedAt = message.ModifiedAt;
        IsRead = message.IsRead;
        IsDeleted = message.IsDeleted;
        AuthorId = message.AuthorId;
        AuthorLogin = message.Author?.Login;
        ChannelId = message.ChannelId;
        CreatedAt = message.CreatedAt;
        Attachments = message
            .Attachments
            .Select(
                attachment =>
                    new ChatServiceLoadAttachmentResponse()
                    {
                        Id = attachment.Id,
                        Type = attachment.Type,
                        Name = attachment.Name,
                        Size = attachment.Size,
                    }
            );
    }
}