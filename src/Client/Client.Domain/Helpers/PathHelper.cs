using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
