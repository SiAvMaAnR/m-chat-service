using Messenger.Application.Services.ChatService.Models;
using Messenger.Domain.Common;
using Messenger.Domain.Entities.Attachments;
using Messenger.Domain.Exceptions;
using Messenger.Persistence.Extensions;

namespace Messenger.Application.Services.ChatService.Extensions;

public static class ProcessAttachmentsExtension
{
    private static string TrimBase64(AttachmentRequest attachment)
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

    public static async Task<Attachment[]> ProcessAttachmentsAsync(
        this IEnumerable<AttachmentRequest> attachments,
        IAppSettings appSettings
    )
    {
        string filePath = appSettings.FilePath.File;

        IEnumerable<Task<Attachment>> tasks = attachments.Select(async attachment =>
        {
            string content = TrimBase64(attachment);

            byte[] fileBytes = Convert.FromBase64String(content);

            string? file = await fileBytes.WriteToFileAsync(
                filePath,
                attachment.Type.Replace("/", ".")
            );

            return new Attachment(file ?? "Failed", attachment.Type);
        });

        return await Task.WhenAll(tasks);
    }
}
