



using Client.Domain.Entites;

namespace Client.Persistence.Repositories;

public class DownloadFileRepository : BaseRepository, IDownloadFileRepository
{
    public DownloadFileRepository(FdmDbContext context) : base(context)
    {
    }

    public async Task<DownloadFile> AddAsync(DownloadFile downloadFile)
    {
        await _context.DownloadFiles.AddAsync(downloadFile);
        await _context.SaveChangesAsync();
        return downloadFile;
    }

    public Task<List<DownloadFile>> AddAsync(List<DownloadFile> downloadFiles)
    {
        throw new NotImplementedException();
    }

    public async Task<List<DownloadFile>> GetAsync(int? queueId)
    {
        var query = _context.DownloadFiles.
            Include(d => d.DownloadQueue)
             .Where(d => d.IsDeleted == false);

        if (queueId != null)
            query = query.Where(d => d.DownloadQueue.Id == queueId);

        return await query.ToListAsync();
    }

    public async Task<List<DownloadFile>> GetsStartedAsync()
    {
        var query = _context.DownloadFiles.
            Include(d => d.DownloadQueue)
             .Where(d => d.IsDeleted == false/* && d.DownloadStatus==DownloadStatus.Started*/);

        return await query.ToListAsync();
    }



    public async Task<DownloadFile?> GetAsync(string fileName, string downloadUrl)
    {
        return await _context.DownloadFiles.
            FirstOrDefaultAsync(d => d.IsDeleted == false &&
            d.FileName == fileName && d.DownloadPath == downloadUrl
            );
    }
    public async Task<DownloadFile?> GetByIdAsync(long id)
    {
        return await _context.DownloadFiles.
            FirstOrDefaultAsync(d => d.IsDeleted == false &&
            d.Id == id);
    }

    public async Task<List<DownloadFile>> GetByIdsAsync(List<long> ids)
    {
        return await _context.DownloadFiles.
            Where(d => d.IsDeleted == false &&
           ids.Contains(d.Id)).ToListAsync();
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
        await _context.SaveChangesAsync();
        return downloadFile;
    }

    public async Task<List<DownloadFile>> UpdateAsync(List<DownloadFile> downloadFiles)
    {
        _context.DownloadFiles.UpdateRange(downloadFiles);
        await _context.SaveChangesAsync();
        return downloadFiles;
    }
}
