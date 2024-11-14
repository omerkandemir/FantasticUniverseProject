using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class Ability : BaseEntity<int>
{
    public string Name { get; set; }
    public int AbilityTypeId { get; set; }
    public AbilityType AbilityType { get; set; }
    public int AbilityCategoryId { get; set; }
    public AbilityCategory AbilityCategory { get; set; }
    public ICollection<AbilityCharacter> AbilityCharacters { get; set; }
}
