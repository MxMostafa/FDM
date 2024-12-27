

namespace Client.Domain.Entites;

public class DownloadFileChunk : BaseEntity<long>
{
    public required long DownloadFileId { get; set; } = 0;
    public DownloadFile DownloadFile { get; set; } = null!;
    public long Size { get; set; }
    public int Index { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public required string TempFilePath { get; set; }
    public DownloadFileChunkStatus DownloadFileChunkStatus { get; set; }
}
