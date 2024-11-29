

namespace Client.Domain.Interfaces.Repositories;

public interface IDownloadQueueRepository
{
    Task<List<DownloadQueue>> GetAllAsync();
    Task<DownloadQueue?> GetByTitleAsync(string title);
    Task<bool> AddAsync(string title);
    Task<DownloadQueue?> GetByIdAsync(int id);
    Task<DownloadQueue?> GetMainQueueAsync();
    Task<DownloadQueue> CreateMainQueueAsync();
}
