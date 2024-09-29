using ChatService.Application.Services.ChannelService.Models;
using ChatService.Domain.Entities.Accounts;
using ChatService.Domain.Entities.Channels;
using ChatService.Domain.Entities.Messages;
using ChatService.Domain.Shared.Constants.Common;
using ChatService.Persistence.Extensions;

namespace ChatService.Application.Services.ChatService.Adapters;

public class ChannelServiceAccountChannelListAdapter : ChannelServiceAccountChannelResponseData
{
    private readonly string? _imagePath;

    public ChannelServiceAccountChannelListAdapter(Channel channel, int authorId)
    {
        Id = channel.Id;
        Type = channel.Type;
        LastActivity = channel.LastActivity;
        UnreadMessagesCount = channel.GetUnreadMessagesCount(authorId);

        Message? lastMessage = channel.GetLastMessage();

        if (lastMessage != null)
        {
            LastMessage = new ChannelServiceLastMessageResponseData()
            {
                Author = lastMessage.Author?.Login,
                Content = lastMessage.Text
            };
        }

        if (Type == ChannelType.Direct)
        {
            Account? chatPartner = channel
                .Accounts
                .FirstOrDefault(account => account.Id != authorId);

            if (chatPartner != null)
            {
                _imagePath = chatPartner.Image;
                Name = chatPartner.Login;
            }
        }
        else
        {
            _imagePath = channel.Image;
            Name = channel.Name;
        }
    }

    public async Task LoadImageAsync()
    {
        Image = await FileManager.ReadToBytesAsync(_imagePath);
    }
}

public class ChannelServiceAccountChannelAdapter : ChannelServiceAccountChannelResponse
{
    private readonly string? _imagePath;

    public ChannelServiceAccountChannelAdapter(Channel channel, int authorId)
    {
        Id = channel.Id;
        Type = channel.Type;
        LastActivity = channel.LastActivity;
        UnreadMessagesCount = channel.GetUnreadMessagesCount(authorId);

        Message? lastMessage = channel.GetLastMessage();

        if (lastMessage != null)
        {
            LastMessage = new ChannelServiceLastMessageForOneResponseData()
            {
                Author = lastMessage.Author?.Login,
                Content = lastMessage.Text
            };
        }

        if (Type == ChannelType.Direct)
        {
            Account? chatPartner = channel
                .Accounts
                .FirstOrDefault(account => account.Id != authorId);

            if (chatPartner != null)
            {
                _imagePath = chatPartner.Image;
                Name = chatPartner.Login;
                UserActivityStatus = chatPartner.ActivityStatus;
                UserLastOnlineAt = chatPartner.LastOnlineAt;
            }
        }
        else
        {
            _imagePath = channel.Image;
            Name = channel.Name;
            MembersCount = channel.Accounts.Count;
        }
    }

    public async Task LoadImageAsync()
    {
        Image = await FileManager.ReadToBytesAsync(_imagePath);
    }
}
