using Client.Infrastructure.DbContexts.App;

namespace Client.Persistence.Repositories;
public class CategoryGroupRepository : BaseAppRepository, ICategoryGroupRepository
{
    public CategoryGroupRepository(FdmAppDbContext context) : base(context)
    {
    }

    public Task<List<CategoryGroup>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
