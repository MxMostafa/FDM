

namespace Client.Domain.Interfaces.Repositories;

public interface IDownloadQueueRepository
{
    Task<List<DownloadQueue>> GetAllAsync();
    Task<DownloadQueue?> GetByTitleAsync(string title);
    Task<bool> AddAsync(string title);
}
