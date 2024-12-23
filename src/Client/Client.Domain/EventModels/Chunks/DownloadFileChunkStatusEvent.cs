

namespace Client.Domain.EventModels;

public class DownloadFileChunkStatusEvent
{
    public long DownloadFileChunkId { get; set; }
    public DownloadFileChunkStatus DownloadFileChunkStatus { get; set; }
    public DateTime Timestamp { get; set; }

    public DownloadFileChunkStatusEvent(long downloadFileChunkId, DownloadFileChunkStatus status)
    {
        DownloadFileChunkId = downloadFileChunkId;
        DownloadFileChunkStatus = status;
        Timestamp = DateTime.UtcNow;
    }
}
