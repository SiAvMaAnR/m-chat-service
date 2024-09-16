using Messenger.Application.Services.ChatService.Models;
using Messenger.Domain.Common;
using Messenger.Domain.Entities.Attachments;
using Messenger.Domain.Exceptions;
using Messenger.Persistence.Extensions;

namespace Messenger.Application.Services.ChatService.Extensions;

public static class ProcessAttachment
{
    private static string TrimBase64(ChatServiceUploadAttachmentRequest attachment)
    {
        return attachment.Type switch
        {
            "image/png" => attachment.Content.Replace("data:image/png;base64,", ""),
            "image/jpeg" => attachment.Content.Replace("data:image/jpeg;base64,", ""),
            "image/jpg" => attachment.Content.Replace("data:image/jpg;base64,", ""),
            "image/gif" => attachment.Content.Replace("data:image/gif;base64,", ""),
            "file" => attachment.Content.Replace("data", ""),
            _ => throw new IncorrectDataException("Unknown format")
        };
    }

    public static async Task<Attachment> CreateFileAsync(
        ChatServiceUploadAttachmentRequest attachment,
        IAppSettings appSettings
    )
    {
        string filePath = appSettings.FilePath.File;

        string content = TrimBase64(attachment);

        byte[] fileBytes = Convert.FromBase64String(content);

        string? file =
            await FileManager.WriteToFileAsync(
                fileBytes,
                filePath,
                attachment.Type.Replace("/", ".")
            ) ?? throw new IncorrectDataException("Failed to create file", true);

        return new Attachment(file, attachment.Type, attachment.UniqueId);
    }

    public static bool RemoveFile(Attachment attachment)
    {
        return FileManager.RemoveFile(attachment.Content);
    }
}
