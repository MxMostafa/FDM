
namespace Client.Domain.Entites;

public class FileTypeGroup : BaseEntity<int>, ISoftDeletableEntity
{
    public required string Title { get; set; }
    public string? FileExtensions { get; set; }
    public string? IconName { get; set; }
    public bool IsDeleted { get; set; }
    public required string SavePath { get; set; }
    public string? FolderName { get; set; }
}
