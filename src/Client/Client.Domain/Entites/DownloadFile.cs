namespace Client.Domain.Entites;
public class DownloadFile : BaseEntity<long>, ISoftDeletableEntity
{
    public DownloadFile()
    {
    }

    public required int DownloadQueueId { get; set; }
    public required string FileName { get; set; }

    public int? FileTypeGroupId { get; set; }
    public DownloadStatus DownloadStatus { get; set; }
    public long Size { get; set; }
    public long DownloadedBytes { get; set; }
    public required string LocalSavePath { get; set; }
    public required string DownloadPath { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }

}
