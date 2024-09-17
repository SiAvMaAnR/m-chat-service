using Messenger.Application.Services.ChannelService;
using Messenger.Application.Services.ChannelService.Models;
using Messenger.Application.Services.ChatService;
using Messenger.Application.Services.ChatService.Models;
using Messenger.WebApi.Controllers.Models.Chat;
using Messenger.WebApi.Hubs.Common;
using Messenger.WebApi.Hubs.Models.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Messenger.WebApi.Hubs;

public class ChatHub(IChatService chatService, IChannelService channelService) : BaseHub, IHub
{
    private readonly IChatService _chatService = chatService;
    private readonly IChannelService _channelService = channelService;

    [Authorize]
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
    }

    [Authorize]
    public async Task ChannelAsync(ChatHubChannelRequest request)
    {
        ChannelServiceAccountChannelResponse response = await _channelService.AccountChannelAsync(
            new ChannelServiceAccountChannelRequest() { Id = request.ChannelId }
        );

        await Clients.Caller.SendAsync(ChatHubMethod.ChannelResponse, response);
    }

    [Authorize]
    public async Task SendMessageAsync(ChatHubSendMessageRequest request)
    {
        ChatServiceSendMessageResponse response = await _chatService.SendMessageAsync(
            new ChatServiceSendMessageRequest()
            {
                ChannelId = request.ChannelId,
                Message = request.Message,
                Attachments = request.Attachments
            }
        );

        await Clients
            .Users(response.UserIds)
            .SendAsync(ChatHubMethod.SendMessageResponse, response.Message);
    }

    [Authorize]
    public async Task ReadMessageAsync(ChatHubReadMessageRequest request)
    {
        ChatServiceReadMessageResponse response = await _chatService.ReadMessageAsync(
            new ChatServiceReadMessageRequest()
            {
                ChannelId = request.ChannelId,
                MessageId = request.MessageId
            }
        );

        await Clients
            .Users(response.UserIds)
            .SendAsync(ChatHubMethod.ReadMessageResponse, response.ReadMessageIds);

        await Clients
            .Caller
            .SendAsync(
                ChatHubMethod.ReadChannelResponse,
                new { request.ChannelId, response.UnreadMessagesCount }
            );
    }

    [Authorize]
    public async Task<object> LoadFileAsync(ChatHubLoadFileRequest request)
    {
        ChatServiceLoadAttachmentResponse response = await _chatService.LoadAttachmentAsync(
            new ChatServiceLoadAttachmentRequest() { AttachmentId = request.AttachmentId, }
        );

        return response;
    }

    [Authorize]
    public async Task<object> UploadFileAsync(ChatHubUploadFileRequest request)
    {
        ChatServiceUploadAttachmentResponse response = await _chatService.UploadAttachmentAsync(
            new ChatServiceUploadAttachmentRequest()
            {
                UniqueId = request.UniqueId,
                Type = request.Type,
                Content = request.Content,
                Name = request.Name,
                Size = request.Size,
                ChannelId = request.ChannelId
            }
        );

        return response;
    }

    [Authorize]
    public async Task<object> PreviewFilesAsync(ChatHubPreviewFilesRequest request)
    {
        ChatServicePreviewAttachmentsResponse response = await _chatService.PreviewAttachmentsAsync(
            new ChatServicePreviewAttachmentsRequest() { ChannelId = request.ChannelId, }
        );

        return response;
    }

    [Authorize]
    public async Task<object> RemoveFileAsync(ChatHubRemoveFileRequest request)
    {
        ChatServiceRemoveAttachmentResponse response = await _chatService.RemoveAttachmentAsync(
            new ChatServiceRemoveAttachmentRequest() { UniqueId = request.UniqueId }
        );

        return response;
    }
}
