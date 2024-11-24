

namespace Client.Domain.Dtos.Response.FileTypeGroup;

public record FileTypeGroupResDto : IBaseDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public string? FileExtensions { get; set; }
    public string? IconName { get; set; }
    public required string SavePath { get; set; }
    public string? FolderName { get; set; }

}
