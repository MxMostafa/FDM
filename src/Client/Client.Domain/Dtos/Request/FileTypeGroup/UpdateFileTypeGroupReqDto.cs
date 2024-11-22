

namespace Client.Domain.Dtos.Request.FileTypeGroup;

public class UpdateFileTypeGroupReqDto:IBaseDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string FileExtensions { get; set; }
}
