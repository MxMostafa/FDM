







namespace Client.Persistence.Repositories;

public class DownloadFileChunkWriteRepository : BaseChunkRepository, IDownloadFileChunkWriteRepository
{
    public DownloadFileChunkWriteRepository(FdmChunkDbContext context) : base(context)
    {
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


    private static readonly SemaphoreSlim _semaphoreSaveChangesAsync = new(1, 1);
    private async Task SaveChangesAsync()
    {
        await _semaphoreSaveChangesAsync.WaitAsync();
        try
        {
            await _context.SaveChangesAsync();
        }
        finally
        {
            _semaphoreSaveChangesAsync.Release();
        }

    }
}
