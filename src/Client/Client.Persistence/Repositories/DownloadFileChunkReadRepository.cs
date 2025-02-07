



using Client.Domain.Entites;
using Client.Infrastructure.DbContexts.App;
using Client.Infrastructure.DbContexts.Chunk;
using Client.Infrastructure.DbContexts.File;
using System.Security.AccessControl;

namespace Client.Persistence.Repositories;

public class DownloadFileChunkReadRepository : BaseChunkRepository, IDownloadFileChunkReadRepository
{
    public DownloadFileChunkReadRepository(FdmChunkDbContext context) : base(context)
    {
    }

    public Task<List<DownloadFileChunk>> GetByDownloadFileIdAsync(long downloadFileId)
    {
        return _context.DownloadFileChunks.Where(d => d.DownloadFileId == downloadFileId).ToListAsync();
    }

    public Task<List<DownloadFileChunk>> GetByDownloadFileIdAsync(long downloadFileId, DownloadFileChunkStatus downloadFileChunkStatus)
    {
        return _context.DownloadFileChunks
            .Where(d => d.DownloadFileId == downloadFileId && d.DownloadFileChunkStatus == downloadFileChunkStatus).ToListAsync();
    }


    public async Task<DownloadFileChunk?> GetByIdAsync(long downloadFileChunkId)
    {
        return await _context.DownloadFileChunks.FirstOrDefaultAsync(d => d.Id == downloadFileChunkId);
    }

    public async Task<List<DownloadFileChunk>> GetByIdsAsync(List<long> downloadFileChunkIds)
    {
        return await _context.DownloadFileChunks.Where(d => downloadFileChunkIds.Any(i => i == d.Id)).ToListAsync();
    }

}
