using ChatService.Application.Services.ChatService.Models;
using ChatService.Domain.Common;
using ChatService.Domain.Entities.Attachments;
using ChatService.Domain.Exceptions;
using ChatService.Persistence.Extensions;

namespace ChatService.Application.Services.ChatService.Extensions;

public static class ProcessAttachment
{
    public static async Task<Attachment> CreateFileAsync(
        ChatServiceUploadAttachmentRequest attachment,
        IAppSettings appSettings
    )
    {
        string filePath = appSettings.FilePath.File;

        byte[] fileBytes = Convert.FromBase64String(attachment.Content);

        string? fileContent =
            await FileManager.WriteToFileAsync(
                fileBytes,
                filePath,
                attachment.Type.Replace("/", ".")
            ) ?? throw new IncorrectDataException("Failed to create file", true);

        return new Attachment(
            fileContent,
            attachment.Type,
            attachment.Name,
            attachment.Size,
            attachment.UniqueId
        );
    }

    public static bool RemoveFile(Attachment attachment)
    {
        return FileManager.RemoveFile(attachment.Content);
    }
}
