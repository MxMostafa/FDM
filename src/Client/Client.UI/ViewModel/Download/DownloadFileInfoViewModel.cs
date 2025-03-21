﻿

namespace Client.UI.ViewModel.Download;

public class DownloadFileInfoViewModel
{
    public string DownloadURL { get; set; } = null!;
    public string Size { get; set; }
    public string MimeType { get; set; }
    public string FileExtension { get; set; }
    public Icon Icon { get; set; }
}
