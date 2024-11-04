namespace Client.Domain.Interfaces.Services;

public interface ICategoryService
{
    Task<ResultPattern<List<CategoryGroupResDto>>> GetCategoryGroupsAsync();
}
