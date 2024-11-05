

namespace Client.Domain.Entites.Base;

public interface  ISoftDeletableEntity
{
    public bool IsDeleted { get; set; }
}
