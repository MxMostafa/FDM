




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

    public async Task<ResultPattern<bool>> AddDownloadQueueAsync(string title)
    {
        var downloadQueue = await _downloadQueueRepo.GetByTitleAsync(title);

        if (downloadQueue != null)
        {
            return new ResultPattern<bool>(Errors.DuplicatedDownloadQueue);
        }

        var result = await _downloadQueueRepo.AddAsync(title);

        return true;
    }
}
