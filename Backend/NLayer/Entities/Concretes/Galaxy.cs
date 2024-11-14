using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class Galaxy : BaseEntity<int>
{
    public int? UniverseId { get; set; }
    public Universe? Universe { get; set; }
    public string Name { get; set; }
    public List<Star>? Stars { get; set; }
}
