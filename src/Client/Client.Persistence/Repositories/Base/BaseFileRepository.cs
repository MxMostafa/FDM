using Client.Infrastructure.DbContexts.File;

namespace Client.Persistence.Repositories.Base;

public abstract class BaseFileRepository
{
    public readonly FdmFileDbContext _context;


    public BaseFileRepository(FdmFileDbContext context)
    {
        _context = context;
    }

}
