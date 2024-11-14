
namespace Client.Domain.Helpers;

public static class MimeTypeHelper
{
  
   

    public static Icon? GetIconForExtension(string extension)
    {
        string tempFilePath = Path.Combine(Path.GetTempPath(), $"tempfile{extension}");
        File.WriteAllText(tempFilePath, "");

        Icon fileIcon = Icon.ExtractAssociatedIcon(tempFilePath);

        File.Delete(tempFilePath);

        return fileIcon;
    }
}
