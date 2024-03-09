using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class AdventureCharacter : BaseEntity<int>
{
    public int AdventureId { get; set; }
    public Adventure Adventure { get; set; }
    public int CharacterId { get; set; }
    public Character Character { get; set; }
}
