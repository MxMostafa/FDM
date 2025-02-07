

using Client.Infrastructure.DbContexts.App;
using Client.Infrastructure.DbContexts.Chunk;
using Client.Infrastructure.DbContexts.File;

namespace Client.Persistence.Repositories.Base;

public abstract class BaseAppRepository
{
    public readonly FdmAppDbContext _context;


    public BaseAppRepository(FdmAppDbContext context)
    {
        _context = context;
    }

}
