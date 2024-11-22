

namespace Client.Persistence.Repositories.Base;

public abstract class BaseRepository
{
    public readonly FdmDbContext _context;


    public BaseRepository(FdmDbContext context)
    {
        _context = context;
    }

}
