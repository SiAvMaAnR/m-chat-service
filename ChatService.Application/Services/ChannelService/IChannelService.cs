using ChatService.Application.Services.ChannelService.Models;
using ChatService.Application.Services.Common;

namespace ChatService.Application.Services.ChannelService;

public interface IChannelService : IBaseService
{
    Task<ChannelServiceCreatePublicChannelResponse> CreatePublicChannelAsync(
        ChannelServiceCreatePublicChannelRequest request
    );
    Task<ChannelServiceCreatePrivateChannelResponse> CreatePrivateChannelAsync(
        ChannelServiceCreatePrivateChannelRequest request
    );
    Task<ChannelServiceCreateDirectChannelResponse> CreateDirectChannelAsync(
        ChannelServiceCreateDirectChannelRequest request
    );
    Task<ChannelServiceConnectToChannelResponse> ConnectToChannelAsync(
        ChannelServiceConnectToChannelRequest request
    );
    Task<ChannelServicePublicChannelsResponse> PublicChannelsAsync(
        ChannelServicePublicChannelsRequest request
    );
    Task<ChannelServiceAccountChannelsResponse> AccountChannelsAsync(
        ChannelServiceAccountChannelsRequest request
    );
    Task<ChannelServiceAccountChannelResponse> AccountChannelAsync(
        ChannelServiceAccountChannelRequest request
    );
    Task<ChannelServiceSetUpDirectChannelResponse> SetUpDirectChannelAsync(
        ChannelServiceSetUpDirectChannelRequest request
    );
    Task<ChannelServiceMemberImagesResponse> MemberImagesAsync(
        ChannelServiceMemberImagesRequest request
    );
}
