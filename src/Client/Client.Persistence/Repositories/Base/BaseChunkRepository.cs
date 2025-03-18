namespace Client.Persistence.Repositories.Base;

public abstract class BaseChunkRepository
{
    public readonly FdmChunkDbContext _context;


    public BaseChunkRepository(FdmChunkDbContext context)
    {
        _context = context;
    }

}
