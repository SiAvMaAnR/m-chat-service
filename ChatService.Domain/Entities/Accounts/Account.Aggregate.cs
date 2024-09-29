﻿using ChatService.Domain.Entities.Channels;
using ChatService.Domain.Entities.Messages;
using ChatService.Domain.Entities.RefreshTokens;

namespace ChatService.Domain.Entities.Accounts;

public partial class Account : IAggregateRoot
{
    public void UpdateLogin(string login)
    {
        Login = login;
    }

    public void UpdateActivityStatus(string activityStatus)
    {
        ActivityStatus = activityStatus;
        LastOnlineAt = DateTime.Now;
    }

    public void UpdateImage(string? image)
    {
        Image = image;
    }

    public void AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshTokens.Add(refreshToken);
    }

    public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    public void AddChannel(Channel channel)
    {
        Channels.Add(channel);
    }

    public void AddOwnedChannel(Channel channel)
    {
        OwnedChannels.Add(channel);
    }

    public void AddReadMessage(Message message)
    {
        ReadMessages.Add(message);
    }

    public void AddMessage(Message message)
    {
        Messages.Add(message);
    }
}