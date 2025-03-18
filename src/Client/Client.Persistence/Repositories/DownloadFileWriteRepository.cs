using Client.Infrastructure.DbContexts.File;

namespace Client.Persistence.Repositories;

public class DownloadFileWriteRepository : BaseFileRepository, IDownloadFileWriteRepository
{
    private int saveCounter = 0;
    private static readonly SemaphoreSlim _semaphoreSaveChangesAsync = new(1, 1);
    private bool _hasPendingChanges = false;
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public DownloadFileWriteRepository(FdmFileDbContext context) : base(context)
    {
        StartAutoSaveWorker();
    }

    public async Task<DownloadFile> AddAsync(DownloadFile downloadFile)
    {
        await _context.DownloadFiles.AddAsync(downloadFile);
        await SaveChangesAsync();
        return downloadFile;
    }

    public Task<List<DownloadFile>> AddAsync(List<DownloadFile> downloadFiles)
    {
        throw new NotImplementedException();
    }


    public Task<DownloadFile> SoftDeleteAsync(DownloadFile downloadFile)
    {
        throw new NotImplementedException();
    }

    public Task<List<DownloadFile>> SoftDeleteAsync(List<DownloadFile> downloadFiles)
    {
        throw new NotImplementedException();
    }

    public async Task<DownloadFile> UpdateAsync(DownloadFile downloadFile)
    {
        _context.DownloadFiles.Update(downloadFile);
        await SaveChangesAsync();
        return downloadFile;
    }

    public async Task<List<DownloadFile>> UpdateAsync(List<DownloadFile> downloadFiles)
    {
        _context.DownloadFiles.UpdateRange(downloadFiles);
        await SaveChangesAsync();
        return downloadFiles;
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

    public void Dispose()
    {
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
    }

}
