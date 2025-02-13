







namespace Client.Persistence.Repositories;

public class DownloadFileChunkWriteRepository : BaseChunkRepository, IDownloadFileChunkWriteRepository
{
    private int saveCounter = 0;
    private static readonly SemaphoreSlim _semaphoreSaveChangesAsync = new(1, 1);
    private bool _hasPendingChanges = false;
    private readonly CancellationTokenSource _cancellationTokenSource = new();


    public DownloadFileChunkWriteRepository(FdmChunkDbContext context) : base(context)
    {
        StartAutoSaveWorker();
    }


    public async Task<List<DownloadFileChunk>> AddAsync(List<DownloadFileChunk> downloadFileChunks)
    {
        await _context.AddRangeAsync(downloadFileChunks);
        await SaveChangesAsync();
        return downloadFileChunks;
    }

    public async Task<DownloadFileChunk> UpdateAsync(DownloadFileChunk downloadFileChunk)
    {
        _context.Update(downloadFileChunk);
        await SaveChangesAsync();
        return downloadFileChunk;
    }

    public async Task<List<DownloadFileChunk>> UpdateAsync(List<DownloadFileChunk> downloadFileChunks)
    {
        _context.UpdateRange(downloadFileChunks);
        await SaveChangesAsync();
        return downloadFileChunks;
    }


    private async Task SaveChangesAsync()
    {
        await _semaphoreSaveChangesAsync.WaitAsync();
        try
        {
            saveCounter++;
            _hasPendingChanges = true;

            if (saveCounter >= 100)
            {
                saveCounter = 0;
                await CommitChangesAsync();
            }
        }
        finally
        {
            _semaphoreSaveChangesAsync.Release();
        }
    }

    private async Task CommitChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            saveCounter = 0;
            _hasPendingChanges = false;
        }
        catch (Exception ex)
        {


        }
    }


    private void StartAutoSaveWorker()
    {
        Task.Run(async () =>
        {
            while (!_cancellationTokenSource.Token.IsCancellationRequested)
            {
                await Task.Delay(10_000); // هر 10 ثانیه بررسی کن

                await _semaphoreSaveChangesAsync.WaitAsync();
                try
                {
                    if (_hasPendingChanges)
                    {
                        await CommitChangesAsync();
                    }
                }
                finally
                {
                    _semaphoreSaveChangesAsync.Release();
                }
            }
        }, _cancellationTokenSource.Token);
    }

}
