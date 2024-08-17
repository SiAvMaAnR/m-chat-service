namespace Messenger.Domain.Shared.Settings;

public class FilePathSettings : ISettings
{
    public static string Path => "FilePath";

    public string Image { get; set; } = null!;
    public string Logger { get; set; } = null!;
}
