namespace Client.Domain.Entites;
public class Download : BaseEntity<int>
{
    public required string FileName { get; set; }
    public DownloadFileType DownloadFileType { get; set; }

    public DownloadStatus DownloadStatus { get; set; }
    public int Size { get; set; }
    public required string LocalSavePath { get; set; }
    public required string DownloadPath { get; set; }
    public string? Description { get; set; }

}
