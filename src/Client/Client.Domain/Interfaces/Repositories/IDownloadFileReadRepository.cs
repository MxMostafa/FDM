

namespace Client.Domain.Interfaces.Repositories;

public interface IDownloadFileReadRepository
{
    Task<DownloadFile?> GetAsync(string fileName,string downloadUrl);
    Task<List<DownloadFile>> GetAsync(int? queueId);
    Task<List<DownloadFile>> GetsStartedAsync(DownloadStatus downloadStatus);
    Task<DownloadFile?> GetByIdAsync(long id);
    Task<List<DownloadFile>> GetByIdsAsync(List<long> ids);
    Task<List<DownloadFile>> GetByStatusAsync(DownloadStatus downloadStatus);
}
