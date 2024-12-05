
using System.ComponentModel;

namespace Client.Domain.Dtos.Response.DownloadFile;

public class DownloadFileResDto
{
    public long Id { get; set; }
    public required string FileName { get; set; }
    public required DownloadQueue DownloadQueue { get; set; }
    public long Size { get; set; }
    public DownloadStatus DownloadStatus { get; set; }
    public string? Description { get; set; }
    public long DownloadedBytes { get; set; }
}
