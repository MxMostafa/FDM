


namespace Client.Persistence.Repositories;

public class FileTypeGroupRepository : BaseRepository, IFileTypeGroupRepository
{
    public FileTypeGroupRepository(FdmDbContext context) : base(context)
    {
    }

    public async Task<FileTypeGroup> AddAsync(FileTypeGroup fileTypeGroup)
    {
        await _context.AddAsync(fileTypeGroup);
        await _context.SaveChangesAsync();
        return fileTypeGroup;
    }

    public async Task<bool> DeleteAsync(FileTypeGroup fileTypeGroup)
    {
        _context.Remove(fileTypeGroup);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<FileTypeGroup>> GetAllAsync()
    {
        return await _context.FileTypeGroups.Where(f => f.IsDeleted == false).ToListAsync();
    }

    public async Task<FileTypeGroup?> GetByFileExtensionAsync(string extension)
    {
        return await _context.FileTypeGroups.FirstOrDefaultAsync(f => f.FileExtensions != null && f.FileExtensions.Contains(extension));
    }

    public async Task<FileTypeGroup?> GetByIdAsync(int id)
    {
        return await _context.FileTypeGroups.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<FileTypeGroup?> GetByTitleAsync(string title)
    {
        return await _context.FileTypeGroups.FirstOrDefaultAsync(f => f.Title == title);
    }

    public async Task<FileTypeGroup> UpdateAsync(FileTypeGroup fileTypeGroup)
    {
        _context.Update(fileTypeGroup);
        await _context.SaveChangesAsync();
        return fileTypeGroup;
    }
}
