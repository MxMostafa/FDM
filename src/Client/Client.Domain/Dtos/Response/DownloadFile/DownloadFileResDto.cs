
using System.ComponentModel;

namespace Client.Domain.Dtos.Response.DownloadFile;

public class DownloadFileResDto
{
    public int Id { get; set; }
    public required string FileName { get; set; }
    public required DownloadQueue DownloadQueue { get; set; }
    public long Size { get; set; }
    public DownloadStatus DownloadStatus { get; set; }
    public string? Description { get; set; }
}
