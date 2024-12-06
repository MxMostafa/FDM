

using Client.Infrastructure.Helpers;
using System.IO;

namespace Client.UI.Helpers;

public static class FileIconHelper
{
    private static Dictionary<string, Icon?> fileIcons = new Dictionary<string, Icon?>();

    public static Icon? GetIconByExtension(string fileName)
    {
        var extension = Path.GetExtension(fileName);

        var item = fileIcons.FirstOrDefault(k => k.Key == extension);

        if (item.Value != null) return item.Value;

        var icon = MimeTypeHelper.GetIconForExtension(fileName);
        fileIcons.Add(extension, icon);
        return icon;

    }
}
