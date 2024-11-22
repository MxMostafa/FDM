



namespace Client.Persistence.Repositories;

public class DownloadQueueRepository : BaseRepository, IDownloadQueueRepository
{
    public DownloadQueueRepository(FdmDbContext context) : base(context)
    {
    }

    public async Task<List<DownloadQueue>> GetAllAsync()
    {
        return await _context.DownloadQueues.ToListAsync();
    }

    public async Task<bool> AddAsync(string title)
    {
        await _context.DownloadQueues.AddAsync(new DownloadQueue()
        {
            Id=0,
            Title=title
        });
        return await _context.SaveChangesAsync() > 1;
    }

    public async Task<DownloadQueue?> GetByTitleAsync(string title)
    {

        return await _context.DownloadQueues.FirstOrDefaultAsync(d=>d.Title==title && d.IsDeleted==false);
    }
}
