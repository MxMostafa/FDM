
namespace Client.Domain.Dtos.Response;

public record CategoryGroupResDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
}
