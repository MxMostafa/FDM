

namespace Client.Domain.Dtos;

public class Pagination
{
    public int? PageNumber { get; set; } = 0;
    public int? PageSize { get; set; } = 10;
    public int? TotalCount { get; set; }
}
