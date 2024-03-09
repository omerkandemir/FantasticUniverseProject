using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class UnionCharacter : BaseEntity<int>
{
    public int UnionId { get; set; }
    public Union Union { get; set; }
    public int CharacterId { get; set; }
    public Character Character { get; set; }
}
