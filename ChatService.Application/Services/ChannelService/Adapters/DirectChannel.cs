using ChatService.Application.Services.ChannelService.Models;
using ChatService.Domain.Entities.Accounts;
using ChatService.Domain.Entities.Channels;
using ChatService.Domain.Entities.Messages;
using ChatService.Persistence.Extensions;

public class ChannelServiceDirectChannelAdapter : ChannelServiceDirectChannel
{
    private readonly string? _imagePath;

    public ChannelServiceDirectChannelAdapter(Channel channel, int authorId)
    {
        Id = channel.Id;
        Type = channel.Type;
        LastActivity = channel.LastActivity;

        Message? lastMessage = channel.GetLastMessage();

        if (lastMessage != null)
        {
            LastMessage = new ChannelServiceLastMessageForOneResponseData()
            {
                Author = lastMessage.Author?.Login,
                Content = lastMessage.Text
            };
        }

        Account? chatPartner = channel.Accounts.FirstOrDefault(account => account.Id != authorId);

        if (chatPartner != null)
        {
            _imagePath = chatPartner.Image;
            Name = chatPartner.Login;
            UserActivityStatus = chatPartner.ActivityStatus;
            UserLastOnlineAt = chatPartner.LastOnlineAt;
        }
    }

    public async Task LoadImageAsync()
    {
        Image = await FileManager.ReadToBytesAsync(_imagePath);
    }
}
