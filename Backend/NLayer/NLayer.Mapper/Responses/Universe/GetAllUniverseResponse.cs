using NLayer.Core.Dto.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Mapper.Responses.Universe;

public class GetAllUniverseResponse : IGetResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public ThemeSetting ThemeSetting { get; set; } 
}