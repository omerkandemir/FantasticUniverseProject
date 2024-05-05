using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Star;

public class CreateStarRequest : ICreateRequest
{
    public int GalaxyId { get; set; }
    public string Name { get; set; }
}
