﻿

namespace Client.Domain.Entites;

public class DownloadFileChunk : BaseEntity<long>
{
    public long DownloadFileId { get; set; }
    public DownloadFile DownloadFile { get; set; } = null!;

    public int Index { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public required string TempFilePath { get; set; }
    public DownloadFileChunkStatus DownloadFileChunkStatus { get; set; }
}
