using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class AbilityCharacter : BaseEntity<int>
{
    public int AbilityId { get; set; }
    public Ability Ability { get; set; }
    public int CharacterId { get; set; }
    public Character Character { get; set; }
}
