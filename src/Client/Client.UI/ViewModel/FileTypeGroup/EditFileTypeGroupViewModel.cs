using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.UI.ViewModel.FileTypeGroup
{
    public class EditFileTypeGroupViewModel
    {

        public required int Id { get; set; }
        public required string Title { get; set; }
        public string FileExtensions { get; set; }
        public string IconName { get; set; }
    }
}
