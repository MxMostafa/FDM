using Client.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain.SeedData
{
    public static class FileTypeGroupSeed
    {
        public static IEnumerable<FileTypeGroup> GetSeedData()
        {
            return new List<FileTypeGroup>
        {
            new FileTypeGroup { Id = 1, Title = FileTypeGroupEnum.CompressFiles, FileExtensions = FileTypeGroupEnum.CompressFilesExtensions,SavePath=PathHelper.GetDefaultDownloadPath(FileTypeGroupEnum.CompressFilesFolderName),FolderName= FileTypeGroupEnum.CompressFilesFolderName,IsDeleted = false },
            new FileTypeGroup { Id = 2, Title = FileTypeGroupEnum.DocumentFiles, FileExtensions = FileTypeGroupEnum.DocumentFilesExtensions,SavePath=PathHelper.GetDefaultDownloadPath(FileTypeGroupEnum.DocumentFilesFolderName),FolderName= FileTypeGroupEnum.DocumentFilesFolderName, IsDeleted = false },
            new FileTypeGroup { Id = 3, Title = FileTypeGroupEnum.AudioFiles, FileExtensions = FileTypeGroupEnum.AudioFilesExtensions,SavePath=PathHelper.GetDefaultDownloadPath(FileTypeGroupEnum.AudioFilesFolderName),FolderName= FileTypeGroupEnum.AudioFilesFolderName, IsDeleted = false },
            new FileTypeGroup { Id = 4, Title = FileTypeGroupEnum.ProgramFiles, FileExtensions = FileTypeGroupEnum.ProgramFilesExtensions,SavePath=PathHelper.GetDefaultDownloadPath(FileTypeGroupEnum.ProgramFilesFolderName),FolderName= FileTypeGroupEnum.ProgramFilesFolderName, IsDeleted = false },
            new FileTypeGroup { Id = 5, Title = FileTypeGroupEnum.VideoFiles, FileExtensions = FileTypeGroupEnum.VideoFilesExtensions,SavePath=PathHelper.GetDefaultDownloadPath(FileTypeGroupEnum.VideoFilesFolderName),FolderName= FileTypeGroupEnum.VideoFilesFolderName, IsDeleted = false },
        };
        }
    }
}
