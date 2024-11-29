using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class Star : BaseEntity<int>
{
    public int? GalaxyId { get; set; }
    public Galaxy? Galaxy { get; set; }
    public string Name { get; set; }
    public List<Planet>? Planets { get; set; }
}
