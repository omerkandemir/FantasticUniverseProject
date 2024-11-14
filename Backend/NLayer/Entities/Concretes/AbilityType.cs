using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class AbilityType : BaseEntity<int>
{
    public string TypeName { get; set; }
    public string Description { get; set; }
    public ICollection<Ability> Abilities { get; set; }
}
