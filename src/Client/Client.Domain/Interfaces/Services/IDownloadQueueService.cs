

namespace Client.Domain.Interfaces.Services;

public interface IDownloadQueueService
{
    Task<List<DownloadQueueResDto>> GetAllDownloadQueuesAsync();
    Task<ResultPattern<bool>> AddDownloadQueueAsync(string title);
}
