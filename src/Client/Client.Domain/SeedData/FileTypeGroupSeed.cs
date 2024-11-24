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
            new FileTypeGroup { Id = 1, Title = FileTypeGroupEnum.CompressFiles, FileExtensions = FileTypeGroupEnum.CompressFilesExtensions, IsDeleted = false },
            new FileTypeGroup { Id = 2, Title = FileTypeGroupEnum.DocumentFiles, FileExtensions = FileTypeGroupEnum.DocumentFilesExtensions, IsDeleted = false },
            new FileTypeGroup { Id = 3, Title = FileTypeGroupEnum.AudioFiles, FileExtensions = FileTypeGroupEnum.AudioFilesExtensions, IsDeleted = false },
            new FileTypeGroup { Id = 4, Title = FileTypeGroupEnum.ProgramFiles, FileExtensions = FileTypeGroupEnum.ProgramFilesExtensions, IsDeleted = false },
            new FileTypeGroup { Id = 5, Title = FileTypeGroupEnum.VideoFiles, FileExtensions = FileTypeGroupEnum.VideoFilesExtensions, IsDeleted = false },
        };
        }
    }
}
