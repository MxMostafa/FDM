

namespace Client.Domain.Interfaces.Services;

public interface IDownloadQueueService
{
    Task<ResultPattern< List<DownloadQueueResDto>>> GetAllDownloadQueuesAsync();
    Task<ResultPattern<bool>> CreateNewDownloadQueueAsync(string title);


}
