

namespace Client.Domain.Interfaces.Repositories;

public interface IDownloadQueueRepository
{
    Task<List<DownloadQueue>> GetAllAsync();
}
