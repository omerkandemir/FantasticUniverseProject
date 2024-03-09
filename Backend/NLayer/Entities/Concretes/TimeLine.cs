using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class TimeLine : BaseEntity<int>
{
    public int UniverseId { get; set; }
    public Universe Universe { get; set; }
    public int StartingAdventureId { get; set; }
    public Adventure Adventure { get; set; }
    public ICollection<Universe> Universes { get; set; }
}
