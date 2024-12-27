

using Client.Domain.Entites;

namespace Client.Domain.EventModels;

public class DownloadFileChunkStatusEvent
{
    public long DownloadFileChunkId { get; set; }
    public long DownloadFileId { get; set; }
    public long ChunkSize { get; set; }
    public DownloadFileChunkStatus DownloadFileChunkStatus { get; set; }
    public DateTime Timestamp { get; set; }

    public DownloadFileChunkStatusEvent(long downloadFileId, long downloadFileChunkId, DownloadFileChunkStatus status, long chunkSize)
    {
        DownloadFileId = downloadFileId;
        DownloadFileChunkId = downloadFileChunkId;
        ChunkSize = chunkSize;
        DownloadFileChunkStatus = status;
        Timestamp = DateTime.UtcNow;
    }
}
