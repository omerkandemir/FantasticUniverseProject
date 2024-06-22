using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class UniverseImage : BaseEntity<int>
{
    public int UniverseId { get; set; }
    public Universe Universe { get; set; }
    public byte[] ImageURL { get; set; }
}
