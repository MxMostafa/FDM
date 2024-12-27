



using Client.Domain.Entites;
using System.Security.AccessControl;

namespace Client.Persistence.Repositories;

public class DownloadFileChunkRepository : BaseRepository, IDownloadFileChunkRepository
{
    public DownloadFileChunkRepository(FdmDbContext context) : base(context)
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

    public async Task<List<DownloadFileChunk>> AddAsync(List<DownloadFileChunk> downloadFileChunks)
    {
        await _context.AddRangeAsync(downloadFileChunks);
        await _context.SaveChangesAsync();
        return downloadFileChunks;
    }

    public async Task<DownloadFileChunk?> GetByIdAsync(long downloadFileChunkId)
    {
        return await _context.DownloadFileChunks.FirstOrDefaultAsync(d => d.Id == downloadFileChunkId);
    }

    public async Task<List<DownloadFileChunk>> GetByIdsAsync(List<long> downloadFileChunkIds)
    {
        return await _context.DownloadFileChunks.Where(d => downloadFileChunkIds.Any(i => i == d.Id)).ToListAsync();
    }

    public async Task<DownloadFileChunk> UpdateAsync(DownloadFileChunk downloadFileChunk)
    {
        _context.Update(downloadFileChunk);
        await _context.SaveChangesAsync();
        return downloadFileChunk;
    }

    public async Task<List<DownloadFileChunk>> UpdateAsync(List<DownloadFileChunk> downloadFileChunks)
    {
        _context.UpdateRange(downloadFileChunks);
        await _context.SaveChangesAsync();
        return downloadFileChunks;
    }
}
