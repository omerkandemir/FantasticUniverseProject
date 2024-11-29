using NLayer.Core.Dto.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Mapper.Requests.Universe;

public class CreateUniverseRequest : ICreateRequest
{
    public string Name { get; set; }
    public ThemeSetting ThemeSetting { get; set; }
    // Galaxies JSON formatında gelen veriyi burada tutacağız
    public string? GalaxiesJson { get; set; }
    public ICollection<Entities.Concretes.Galaxy>? Galaxies { get; set; } = new List<Entities.Concretes.Galaxy>();
}
