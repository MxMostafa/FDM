﻿


using Client.Infrastructure.DbContexts.App;

namespace Client.Persistence.Repositories;

public class FileTypeGroupRepository : BaseAppRepository, IFileTypeGroupRepository
{
    public FileTypeGroupRepository(FdmAppDbContext context) : base(context)
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
        return await _context.FileTypeGroups.FirstOrDefaultAsync(f =>f.IsDeleted==false && f.FileExtensions != null && f.FileExtensions.Contains(extension));
    }

    public async Task<FileTypeGroup?> GetByIdAsync(int id)
    {
        return await _context.FileTypeGroups.FirstOrDefaultAsync(f => f.IsDeleted == false && f.Id == id);
    }

    public async Task<FileTypeGroup?> GetByTitleAsync(string title)
    {
        return await _context.FileTypeGroups.FirstOrDefaultAsync(f => f.IsDeleted == false && f.Title == title);
    }

    public async Task<FileTypeGroup> UpdateAsync(FileTypeGroup fileTypeGroup)
    {
        _context.Update(fileTypeGroup);
        await _context.SaveChangesAsync();
        return fileTypeGroup;
    }



    public async Task<FileTypeGroup> SoftDeleteAsync(FileTypeGroup fileTypeGroup)
    {
        fileTypeGroup.IsDeleted = true;
        _context.Update(fileTypeGroup);
        await _context.SaveChangesAsync();
        return fileTypeGroup;
    }
}
