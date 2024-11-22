

namespace Client.Domain.Dtos.Request.FileTypeGroup;

public class AddFileTypeGroupReqDto:IBaseDto
{
    public required string Title { get; set; }
    public required string FileExtensions { get; set; }
}
