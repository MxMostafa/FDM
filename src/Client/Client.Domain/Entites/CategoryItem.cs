
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Domain.Entites;

public class CategoryItem : BaseEntity<int>
{
    [ForeignKey("CategoryGroup")]
    public required int CategoryGroupId { get; set; }
    public required CategoryGroup CategoryGroup { get; set; }
    public required string Title { get; set; }
}
