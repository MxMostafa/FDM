

namespace Client.Domain.EventModels;

public class DownloadFileDownloadedBytesEvent
{
    public long DownloadFileId { get; set; }
    public long DownloadBytes { get; set; }
    public DateTime Timestamp { get; set; }

    public DownloadFileDownloadedBytesEvent(long downloadFileId, long downloadBytes)
    {
        DownloadFileId = downloadFileId;
        DownloadBytes = downloadBytes;
        Timestamp = DateTime.UtcNow;
    }
}
