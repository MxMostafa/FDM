

namespace Client.Domain.Entites;

public class DownloadFileChunk: BaseEntity<long>
{
    public int DownloadFileId { get; set; }
    public required DownloadFile DownloadFile { get; set; }

    public int Index { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public required string TempFilePath { get; set; }
    public DownloadFileChunkStatus DownloadFileChunkStatus { get; set; }
}
