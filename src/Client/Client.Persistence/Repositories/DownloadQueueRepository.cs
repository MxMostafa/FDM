



using Client.Infrastructure.DbContexts.App;

namespace Client.Persistence.Repositories;

public class DownloadQueueRepository : BaseAppRepository, IDownloadQueueRepository
{
    public DownloadQueueRepository(FdmAppDbContext context) : base(context)
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
            Id = 0,
            Title = title
        });
        return await _context.SaveChangesAsync() > 1;
    }

    public async Task<DownloadQueue?> GetByTitleAsync(string title)
    {

        return await _context.DownloadQueues.FirstOrDefaultAsync(d => d.Title == title && d.IsDeleted == false);
    }

    public async Task<DownloadQueue?> GetByIdAsync(int id)
    {

        return await _context.DownloadQueues.FirstOrDefaultAsync(d => d.Id == id && d.IsDeleted == false);
    }

    public async Task<DownloadQueue?> GetMainQueueAsync()
    {
        return await _context.DownloadQueues.FirstOrDefaultAsync(d => d.Title == DownloadQueueEnum.MainDownloadQueue && d.IsDeleted == false);
    }

    public async Task<DownloadQueue> CreateMainQueueAsync()
    {
        var queue = new DownloadQueue()
        {
            Id = 0,
            Title = DownloadQueueEnum.MainDownloadQueue
        };

        await _context.DownloadQueues.AddAsync(queue);
        await _context.SaveChangesAsync();
        return queue;
    }
}
