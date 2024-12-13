

namespace Client.Domain.EventModels;

public class DownloadFileStatusEvent
{
    public long DownloadFileId { get; set; }
    public DownloadStatus DownloadStatus { get; set; }
    public DateTime Timestamp { get; set; }

    public DownloadFileStatusEvent(long downloadFileId, DownloadStatus downloadStatus)
    {
        DownloadFileId = downloadFileId;
        DownloadStatus = downloadStatus;
        Timestamp = DateTime.UtcNow;
    }
}
