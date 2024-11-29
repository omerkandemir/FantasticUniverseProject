using NLayer.Core.Dto.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Mapper.Requests.Universe;

public class UpdateUniverseRequest : IUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ThemeSetting ThemeSetting { get; set; }
    public ICollection<Entities.Concretes.Galaxy>? Galaxies { get; set; } = new List<Entities.Concretes.Galaxy>();
}
