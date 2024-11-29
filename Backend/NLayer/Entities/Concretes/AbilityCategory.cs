using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class AbilityCategory : BaseEntity<int>
{
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public ICollection<Ability> Abilities { get; set; }
}
