

using Client.Domain.Dtos.Response.DownloadQueueItem;

namespace Client.Domain.Interfaces.Repositories;

public interface IHttpRepository
{
    Task<ResultPattern<DownloadFileInfoResDto>> GetFileInfoAsync(string url);
}
