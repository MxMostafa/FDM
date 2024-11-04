



namespace Client.Domain.Interfaces.Repositories;

public interface ICategoryGroupRepository
{
    Task<List<CategoryGroup>> GetAllAsync();
}
