
namespace Client.Domain.Dtos.Response.ChunkFile;

public class DownloadFileChunkResDto
{
    public int Id { get; set; }
    public long DownloadFileId { get; set; }
    public int Index { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public required string DownloadUrl { get; set; }
    public required string TempFilePath { get; set; }
    public DownloadFileChunkStatus DownloadFileChunkStatus { get; set; }
    public long Size { get; set; }
}
