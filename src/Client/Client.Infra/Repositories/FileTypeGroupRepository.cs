


namespace Client.Infra.Repositories;

public class FileTypeGroupRepository : BaseRepository, IFileTypeGroupRepository
{
    public FileTypeGroupRepository(FdmDbContext context) : base(context)
    {
    }

    public async Task<bool> AddAsync(FileTypeGroup fileTypeGroup)
    {
        try
        {
            await _context.FileTypeGroups.AddAsync(fileTypeGroup);
            return await _context.SaveChangesAsync() > 1;
        }
        catch (Exception ex)
        {

            throw new NotImplementedException();
        }
    }

    public Task<bool> DeleteAsync(FileTypeGroup fileTypeGroup)
    {
        throw new NotImplementedException();
    }

    public async Task<List<FileTypeGroup>> GetAllAsync()
    {
        return await _context.FileTypeGroups.ToListAsync();
    }

    public async Task<FileTypeGroup?> GetByFileExtensionAsync(string extension)
    {
        return await _context.FileTypeGroups.FirstOrDefaultAsync(d => d.FileExtensions == extension && d.IsDeleted == false);
    }

    public async Task<FileTypeGroup?> GetByIdAsync(int id)
    {
        return await _context.FileTypeGroups.FirstOrDefaultAsync(d => d.Id == id && d.IsDeleted == false);
    }

    public async Task<FileTypeGroup?> GetByTitleAsync(string Title)
    {
        
        return await _context.FileTypeGroups.FirstOrDefaultAsync(d => d.Title == Title && d.IsDeleted == false);
    }

    public Task<FileTypeGroup> UpdateAsync(FileTypeGroup fileTypeGroup)
    {
        throw new NotImplementedException();
    }

    
}
