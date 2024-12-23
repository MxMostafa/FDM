

namespace Client.Application.Models;

public class ActiveDownloadChunkItemModel
{
    public long Id { get; set; }
    public long DownloadFileId { get; set; }
    public required string DownloadUrl { get; set; }
    public int Index { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public required string TempFilePath { get; set; }
    public DownloadFileChunkStatus DownloadFileChunkStatus { get; set; }
    public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();
    public int? TaskId { get; set; }
    public long DownloadedBytes { get; set; }

}
