



namespace Client.Domain.Dtos.Response;

public record DownloadQueueResDto:IBaseDto
{
    public string Title { get; set; } = null!;
}
