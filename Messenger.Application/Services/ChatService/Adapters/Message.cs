﻿using Messenger.Application.Services.ChatService.Models;
using Messenger.Domain.Entities.Messages;
using Messenger.Persistence.Extensions;

namespace Messenger.Application.Services.ChatService.Adapters;

public class ChatServiceMessageAdapter : ChatServiceMessageResponseData
{
    private readonly Message _message;
    private static readonly SemaphoreSlim _semaphore = new(4);

    public ChatServiceMessageAdapter(Message message)
    {
        _message = message;

        Id = message.Id;
        Text = message.Text;
        ModifiedAt = message.ModifiedAt;
        IsRead = message.IsRead;
        IsDeleted = message.IsDeleted;
        AuthorId = message.AuthorId;
        AuthorLogin = message.Author?.Login;
        ChannelId = message.ChannelId;
        CreatedAt = message.CreatedAt;
    }

    public async Task<ChatServiceMessageAdapter> LoadAttachmentsAsync()
    {
        IEnumerable<Task<ChatServiceAttachmentResponse>> attachmentsTasks = _message
            .Attachments
            .Select(async attachment =>
            {
                string contentBase64 = string.Empty;

                try
                {
                    byte[] contentBytes =
                        await FileManager.ReadToBytesAsync(attachment.Content) ?? [];

                    contentBase64 = Convert.ToBase64String(contentBytes);
                }
                catch { }

                return new ChatServiceAttachmentResponse()
                {
                    Id = attachment.Id,
                    Content = contentBase64,
                    Type = attachment.Type,
                };
            });

        Attachments = (await Task.WhenAll(attachmentsTasks)).Where(
            attachment => !string.IsNullOrEmpty(attachment.Content)
        );

        return this;
    }
}
