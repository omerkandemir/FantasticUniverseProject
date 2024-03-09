using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class Universe : BaseEntity<int>
{
    public string Name { get; set; }
    public ICollection<Galaxy> Galaxies { get; set; }
    public ICollection<Union> Unions { get; set; }
    public ICollection<TimeLine> TimeLines { get; set; }
}
