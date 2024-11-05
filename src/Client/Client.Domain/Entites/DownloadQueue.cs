

namespace Client.Domain.Entites;

public class DownloadQueue:BaseEntity<int>, ISoftDeletableEntity
{
    public required string Title { get; set; }
    public bool IsDeleted { get; set; }
}
