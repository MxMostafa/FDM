



using Client.Domain.Entites;
using Client.Domain.Enums;
using Client.Infrastructure.DbContexts.App;
using Client.Infrastructure.DbContexts.Chunk;
using Client.Infrastructure.DbContexts.File;

namespace Client.Persistence.Repositories;

public class DownloadFileWriteRepository : BaseFileRepository, IDownloadFileWriteRepository
{
    public DownloadFileWriteRepository(FdmFileDbContext context) : base(context)
    {
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
