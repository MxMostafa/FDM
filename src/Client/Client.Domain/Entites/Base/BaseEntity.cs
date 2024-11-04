namespace Client.Domain.Entites.Base;
public abstract class BaseEntity<T>
{
    public required T Id { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; } = DateTime.Now;

}
