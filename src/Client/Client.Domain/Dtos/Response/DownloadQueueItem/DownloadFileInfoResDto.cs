



namespace Client.Domain.Dtos.Response.DownloadQueueItem;

public record DownloadFileInfoResDto:IBaseDto
{
    public long SizeInBytes { get; set; } = 0;
    public string? MimeType { get; set; }
    public string? FileExtension { get; set; }
    public Icon? Icon { get; set; }
}
