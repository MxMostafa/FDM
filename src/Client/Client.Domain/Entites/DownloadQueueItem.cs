


namespace Client.Domain.Entites;

public class DownloadQueueItem : BaseEntity<int>, ISoftDeletableEntity
{
    public required string FileName { get; set; }
    public required string DownloadUrl { get; set; }
    public DownloadFileType DownloadFileType { get; set; }

    [ForeignKey("DownloadQueue")]
    public required int DownloadQueueId { get; set; }
    public required DownloadQueue DownloadQueue { get; set; }

    /// <summary>
    /// kilo byte size
    /// </summary>
    public long Size { get; set; }

    public required DownloadStatus DownloadStatus { get; set; }
    public bool IsDeleted { get; set; }
}
