namespace Client.Application.Services;

public class DownloadQueueService : IDownloadQueueService
{
    private readonly IDownloadQueueRepository _downloadQueueRepo;
    private readonly IAppErrors _appErrors;

    public DownloadQueueService(IDownloadQueueRepository downloadQueueRepo, IAppErrors appErrors)
    {
        _downloadQueueRepo = downloadQueueRepo;
        _appErrors = appErrors;
    }

    public async Task<ResultPattern<List<DownloadQueueResDto>>> GetAllDownloadQueuesAsync()
    {
        var result = await _downloadQueueRepo.GetAllAsync();

        return result.Select(r => new DownloadQueueResDto()
        {
            Title = r.Title
        }).ToList();
    }

    public async Task<ResultPattern<bool>> CreateNewDownloadQueueAsync(string title)
    {
        var downloadQueue = await _downloadQueueRepo.GetByTitleAsync(title);

        if (downloadQueue != null)
        {
            return new ResultPattern<bool>(_appErrors.DuplicatedDownloadQueue);
        }

        var result = await _downloadQueueRepo.AddAsync(title);

        return true;
    }
}
