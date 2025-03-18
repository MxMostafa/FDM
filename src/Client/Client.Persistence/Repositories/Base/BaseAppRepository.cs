

using Client.Infrastructure.DbContexts.App;

namespace Client.Persistence.Repositories.Base;

public abstract class BaseAppRepository
{
    public readonly FdmAppDbContext _context;


    public BaseAppRepository(FdmAppDbContext context)
    {
        _context = context;
    }

}
