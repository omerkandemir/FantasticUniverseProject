using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Universe;

public class CreateUniverseRequest : ICreateRequest
{
    public string Name { get; set; }
}
