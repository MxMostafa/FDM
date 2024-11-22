

using Client.Domain.Dtos.Response.DownloadQueueItem;

namespace Client.Domain.Interfaces.Services;

public interface IDownloadFileService
{
    Task<ResultPattern<DownloadFileInfoResDto>> GetFileInfoAsync(string url);
}
