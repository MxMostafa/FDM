namespace Client.Domain.Helpers
{
    public static class PathHelper
    {
        public static string GetDefaultDownloadPath(string folderName)
        {
            return Path.Combine(
                           Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                           $"Downloads\\{folderName}");
        }
    }
}
