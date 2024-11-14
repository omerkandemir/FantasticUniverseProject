using NLayer.Core.Dto.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Mapper.Responses.Universe;

public class CreatedUniverseResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }

    public ThemeSetting ThemeSetting { get; set; }
    public List<Entities.Concretes.Galaxy>? Galaxies { get; set; } = new List<Entities.Concretes.Galaxy>();
}
