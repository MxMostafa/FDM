

namespace Client.Domain.Interfaces.Services;

public interface IDownloadQueueService
{
    Task<List<DownloadQueueResDto>> GetAllDownloadQueuesAsync();
}
