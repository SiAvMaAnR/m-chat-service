using Chat.Application.Services.ChatService.Models;
using Chat.Domain.Common;
using Chat.Domain.Entities.Attachments;
using Chat.Domain.Exceptions;
using Chat.Persistence.Extensions;

namespace Chat.Application.Services.ChatService.Extensions;

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
