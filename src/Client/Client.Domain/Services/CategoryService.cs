using Client.Domain.Interfaces.Services;

namespace Client.Domain.Services;

public class CategoryService : ICategoryService
{

    public Task<ResultPattern<List<CategoryGroupResDto>>> GetCategoryGroupsAsync()
    {
        throw new NotImplementedException();
    }
}
