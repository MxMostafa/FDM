



using Client.Domain.Entites;
using Client.Domain.Enums;
using Client.Infrastructure.DbContexts.App;
using Client.Infrastructure.DbContexts.Chunk;
using Client.Infrastructure.DbContexts.File;

namespace Client.Persistence.Repositories;

public class DownloadFileReadRepository : BaseFileRepository, IDownloadFileReadRepository
{
    public DownloadFileReadRepository(FdmFileDbContext context) : base(context)
    {
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

    public async Task<List<DownloadFile>> GetsStartedAsync(DownloadStatus downloadStatus)
    {
        var query = _context.DownloadFiles.
            Include(d => d.DownloadQueue)
             .Where(d => d.IsDeleted == false &&
             (d.DownloadStatus == downloadStatus));

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
        return await _context.DownloadFiles
            .Include(d => d.DownloadFileChunks)
            .FirstOrDefaultAsync(d => d.IsDeleted == false &&
            d.Id == id);
    }

    public async Task<List<DownloadFile>> GetByIdsAsync(List<long> ids)
    {
        return await _context.DownloadFiles.
            Where(d => d.IsDeleted == false &&
           ids.Contains(d.Id)).ToListAsync();
    }

    public async Task<List<DownloadFile>> GetByStatusAsync(DownloadStatus downloadStatus)
    {
        return await _context.DownloadFiles.
            Where(d => d.IsDeleted == false &&
           d.DownloadStatus== downloadStatus).ToListAsync();
    }

}
