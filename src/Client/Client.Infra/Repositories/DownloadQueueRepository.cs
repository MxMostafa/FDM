



namespace Client.Infra.Repositories;

public class DownloadQueueRepository : BaseRepository, IDownloadQueueRepository
{
    public DownloadQueueRepository(FdmDbContext context) : base(context)
    {
    }

    public async Task<List<DownloadQueue>> GetAllAsync()
    {
        return await _context.DownloadQueues.ToListAsync();
    }
}
