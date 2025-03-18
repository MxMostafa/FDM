namespace Client.Domain.Enums
{
    public static class FileTypeGroupEnum
    {
        public static string CompressFiles => "فایل های فشرده";
        public static string CompressFilesFolderName => "Compressed";
        public static string CompressFilesExtensions => "zip rar";

        public static string DocumentFiles => "اسناد";
        public static string DocumentFilesFolderName => "Documents";
        public static string DocumentFilesExtensions => "txt docx xls";

        public static string AudioFiles => "موسیقی";
        public static string AudioFilesFolderName => "Music";
        public static string AudioFilesExtensions => "mp3 wave";

        public static string ProgramFiles => "برنامه ها";
        public static string ProgramFilesFolderName => "Video";
        public static string ProgramFilesExtensions => "exe msi";

        public static string VideoFiles => "تصویری";
        public static string VideoFilesFolderName => "Compressed";
        public static string VideoFilesExtensions => "mpeg 3gp avi flv";
    }
}
