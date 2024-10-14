using Chat.Domain.Common;
using Chat.Domain.Exceptions;
using Chat.Persistence.Extensions;

namespace Chat.Application.Services.AccountService.Extensions;

public static class ProcessImage
{
    public static async Task<string> CreateFileAsync(
        string imgBase64,
        string fileName,
        IAppSettings appSettings
    )
    {
        string imagePath = appSettings.FilePath.Image;

        byte[] fileBytes = Convert.FromBase64String(imgBase64);

        return await FileManager.WriteToFileAsync(fileBytes, imagePath, fileName)
            ?? throw new IncorrectDataException("Failed to create file", true);
    }
}
