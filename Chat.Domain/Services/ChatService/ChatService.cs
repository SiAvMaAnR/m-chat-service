﻿using Chat.Domain.Common;
using Chat.Domain.Entities.Accounts;
using Chat.Domain.Entities.Accounts.AIBots;
using Chat.Domain.Entities.Attachments;
using Chat.Domain.Entities.Channels;
using Chat.Domain.Entities.Messages;
using Chat.Domain.Exceptions;

namespace Chat.Domain.Services.ChatService;

public class ChatBS : DomainService
{
    public ChatBS(IAppSettings appSettings, IUnitOfWork unitOfWork)
        : base(appSettings, unitOfWork) { }

    public async Task<IEnumerable<Message>> MessagesForAIAsync(int channelId)
    {
        IEnumerable<Message>? messages = await _unitOfWork
            .Message
            .GetAllAsync(new MessagesForAISpec(channelId));

        if (messages == null)
            throw new NotExistsException("Messages not exists");

        return messages;
    }

    public async Task<IEnumerable<Message>> MessagesAsync(int channelId, string? searchField)
    {
        IEnumerable<Message>? messages = await _unitOfWork
            .Message
            .GetAllAsync(new MessagesSpec(channelId, searchField));

        if (messages == null)
            throw new NotExistsException("Messages not exists");

        return messages;
    }

    public async Task<Message> MessageAsync(int channelId, int messageId)
    {
        Message? message = await _unitOfWork
            .Message
            .GetAsync(new MessageSpec(channelId, messageId));

        if (message == null)
            throw new NotExistsException("Message not exists");

        return message;
    }

    public async Task<IEnumerable<Message>> ReadMessagesAsync(
        int channelId,
        int lastMessageId,
        int accountId
    )
    {
        IEnumerable<Message>? unreadMessages = await _unitOfWork
            .Message
            .GetAllAsync(new UnreadMessagesSpec(channelId, lastMessageId, accountId));

        if (unreadMessages == null)
            throw new NotExistsException("Messages not exists");

        Account account =
            await _unitOfWork.Account.GetAsync(new AccountByIdSpec(accountId, true))
            ?? throw new NotExistsException("Account not found");

        foreach (Message message in unreadMessages)
        {
            message.Read();
            message.AddReadAccounts(account);
        }

        var readMessages = unreadMessages.ToList();

        await _unitOfWork.SaveChangesAsync();

        return readMessages;
    }

    public async Task<Message> AddMessageAsync(
        int authorId,
        int channelId,
        string messageText,
        IEnumerable<string> attachmentIds
    )
    {
        var message = new Message(authorId, channelId) { Text = messageText };

        IEnumerable<Attachment> attachments = await _unitOfWork
            .Attachment
            .GetAllAsync(new AttachmentsByUniqueIdsSpec(attachmentIds));

        message.AddAttachments(attachments.ToList());

        Channel? channel = await _unitOfWork
            .Channel
            .GetAsync(new AccountChannelSpec(authorId, channelId));

        if (channel == null)
            throw new NotExistsException("Channel not exists");

        channel.AddMessage(message);
        channel.UpdateLastActivity();

        await _unitOfWork.SaveChangesAsync();

        return message;
    }

    public async Task<int> GetAIBotId()
    {
        AIBot aiBot =
            await _unitOfWork.AIBot.GetAsync(new FirstAIBotSpec())
            ?? throw new NotExistsException("AIBot not exists");

        return aiBot.Id;
    }

    public async Task<int?> GetAIProfileIdByChannelIdAsync(int channelId)
    {
        Channel? channel = await _unitOfWork.Channel.GetAsync(new ChannelByIdSpec(channelId));

        if (channel == null)
            throw new NotExistsException("Channel not exists");

        return channel.AIProfileId;
    }

    public async Task<IEnumerable<string>> GetUserIdsByChannelIdAsync(int accountId, int channelId)
    {
        Channel? channel = await _unitOfWork
            .Channel
            .GetAsync(new AccountChannelSpec(accountId, channelId));

        if (channel == null)
            throw new NotExistsException("Channel not exists");

        IEnumerable<string> userIds = channel.Accounts.Select(account => account.Id.ToString());

        return userIds;
    }

    public async Task<int> GetUnreadMessagesCountAsync(int accountId, int channelId)
    {
        Channel? channel = await _unitOfWork
            .Channel
            .GetAsync(new AccountChannelSpec(accountId, channelId));

        if (channel == null)
            throw new NotExistsException("Channel not exists");

        int unreadMessagesCount = channel.GetUnreadMessagesCount(accountId);

        return unreadMessagesCount;
    }
}
