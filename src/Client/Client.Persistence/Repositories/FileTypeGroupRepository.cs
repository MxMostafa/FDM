


namespace Client.Persistence.Repositories;

public class FileTypeGroupRepository : BaseRepository, IFileTypeGroupRepository
{
    public FileTypeGroupRepository(FdmDbContext context) : base(context)
    {
    }

    public Task<FileTypeGroup> AddAsync(FileTypeGroup fileTypeGroup)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(FileTypeGroup fileTypeGroup)
    {
        throw new NotImplementedException();
    }

    public Task<List<FileTypeGroup>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<FileTypeGroup?> GetByFileExtensionAsync(string extension)
    {
        throw new NotImplementedException();
    }

    public Task<FileTypeGroup?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<FileTypeGroup?> GetByTitleAsync(string Title)
    {
        throw new NotImplementedException();
    }

    public Task<FileTypeGroup> UpdateAsync(FileTypeGroup fileTypeGroup)
    {
        throw new NotImplementedException();
    }
}
