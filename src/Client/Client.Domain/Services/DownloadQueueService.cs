


using Client.Domain.Interfaces.Repositories;

namespace Client.Domain.Services;

public class DownloadQueueService : IDownloadQueueService
{
    private readonly IDownloadQueueRepository _downloadQueueRepo;

    public DownloadQueueService(IDownloadQueueRepository downloadQueueRepo)
    {
        _downloadQueueRepo = downloadQueueRepo;
    }

    public async Task<List<DownloadQueueResDto>> GetAllDownloadQueuesAsync()
    {
        var result = await _downloadQueueRepo.GetAllAsync();

        return result.Select(r => new DownloadQueueResDto()
        {
            Title = r.Title
        }).ToList();
    }
}
