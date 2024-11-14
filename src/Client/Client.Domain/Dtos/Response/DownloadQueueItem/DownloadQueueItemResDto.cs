



namespace Client.Domain.Dtos.Response.DownloadQueueItem;

public record DownloadQueueItemResDto : IBaseDto
{
    public int Id { get; set; }
    public string FileName { get; set; } = null!;
    public string FileIcon { get; set; } = null!;
    public string DownloadQueue { get; set; } = null!;
    public int Size { get; set; }
    public string Status { get; set; } = null!;
    public int Percent { get; set; }
    public int Speed { get; set; }
    public int Remain { get; set; }
    public DateTime LatestDownloadDateTime { get; set; }
    public string Description { get; set; } = null!;
}
