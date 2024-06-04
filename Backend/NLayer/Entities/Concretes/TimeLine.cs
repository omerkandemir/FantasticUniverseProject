using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class TimeLine : BaseEntity<int>
{
    public int StartingAdventureId { get; set; }
    public Adventure Adventure { get; set; }
}
