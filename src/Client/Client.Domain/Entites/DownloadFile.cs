namespace Client.Domain.Entites;
public class DownloadFile : BaseEntity<int>, ISoftDeletableEntity
{
    public required DownloadQueue DownloadQueue { get; set; }
    public required string FileName { get; set; }
    public FileTypeGroup? FileTypeGroup { get; set; }
    public DownloadStatus DownloadStatus { get; set; }
    public long Size { get; set; }
    public required string LocalSavePath { get; set; }
    public required string DownloadPath { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
}
