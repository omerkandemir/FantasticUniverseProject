using NLayer.Entities.Concretes;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Universe;

public class GetUniverseResponse : IGetUniverseResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public ThemeSetting ThemeSetting { get; set; }
}
