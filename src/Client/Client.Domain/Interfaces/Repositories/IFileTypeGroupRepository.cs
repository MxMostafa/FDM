

namespace Client.Domain.Interfaces.Repositories;

public interface IFileTypeGroupRepository
{
    Task<List<FileTypeGroup>> GetAllAsync();
    Task<FileTypeGroup?> GetByIdAsync(int id);
    Task<FileTypeGroup?> GetByTitleAsync(string Title);
    Task<FileTypeGroup?> GetByFileExtensionAsync(string extension);
    Task<bool> DeleteAsync(FileTypeGroup fileTypeGroup);
    Task<FileTypeGroup> UpdateAsync(FileTypeGroup fileTypeGroup);
    Task<FileTypeGroup> AddAsync(FileTypeGroup fileTypeGroup);
}
