using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class Species : BaseEntity<int>
{
    public string Name { get; set; }
    public ICollection<Character> Characters { get; set; }
}
