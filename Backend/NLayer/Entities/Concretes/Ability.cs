using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class Ability : BaseEntity<int>
{
    public string Name { get; set; }
    public ICollection<Character> Characters { get; set; }
}
