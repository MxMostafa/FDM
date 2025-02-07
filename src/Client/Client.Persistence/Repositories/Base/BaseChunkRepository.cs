

using Client.Infrastructure.DbContexts.App;
using Client.Infrastructure.DbContexts.Chunk;
using Client.Infrastructure.DbContexts.File;

namespace Client.Persistence.Repositories.Base;

public abstract class BaseChunkRepository
{
    public readonly FdmChunkDbContext _context;


    public BaseChunkRepository(FdmChunkDbContext context)
    {
        _context = context;
    }

}
