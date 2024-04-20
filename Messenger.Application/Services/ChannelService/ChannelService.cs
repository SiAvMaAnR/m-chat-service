﻿using MessengerX.Application.Services.ChannelService.Models;
using MessengerX.Application.Services.Common;
using MessengerX.Domain.Common;
using MessengerX.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace MessengerX.Application.Services.ChannelService;

public class ChannelService : BaseService, IChannelService
{
    private readonly AccountBS _accountBS;
    private readonly ChannelBS _channelBS;

    public ChannelService(
        IUnitOfWork unitOfWork,
        IHttpContextAccessor context,
        IAppSettings appSettings,
        AccountBS accountBS,
        ChannelBS channelBS
    )
        : base(unitOfWork, context, appSettings)
    {
        _accountBS = accountBS;
        _channelBS = channelBS;
    }

    public async Task<ChannelServiceCreateDirectChannelResponse> CreateDirectChannelAsync(
        ChannelServiceCreateDirectChannelRequest request
    )
    {
        await _channelBS.CreateDirectChannelAsync(_userIdentity.Id, request.AccountId);

        return new ChannelServiceCreateDirectChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServiceCreatePrivateChannelResponse> CreatePrivateChannelAsync(
        ChannelServiceCreatePrivateChannelRequest request
    )
    {
        await _channelBS.CreatePrivateChannelAsync(_userIdentity.Id, request.Name);

        return new ChannelServiceCreatePrivateChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServiceCreatePublicChannelResponse> CreatePublicChannelAsync(
        ChannelServiceCreatePublicChannelRequest request
    )
    {
        await _channelBS.CreatePublicChannelAsync(_userIdentity.Id, request.Name);

        return new ChannelServiceCreatePublicChannelResponse() { IsSuccess = true };
    }

    public async Task<ChannelServiceConnectToChannelResponse> ConnectToChannelAsync(
        ChannelServiceConnectToChannelRequest request
    )
    {
        await _channelBS.ConnectToChannelAsync(_userIdentity.Id, request.ChannelId);

        return new ChannelServiceConnectToChannelResponse() { IsSuccess = true };
    }
}
