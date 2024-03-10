using NLayer.Core.Entities.Concrete;


namespace NLayer.Entities.Concretes;

public class Union : BaseEntity<int>
{
    public string Name { get; set; }
    public string Target { get; set; }
    public int? UnionLeaderId { get; set; }
    public int UniverseId { get; set; }
    public Universe Universe { get; set; }
    public ICollection<UnionCharacter> UnionCharacters { get; set; }
}
