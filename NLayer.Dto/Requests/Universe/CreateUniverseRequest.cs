using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Universe;

public class CreateUniverseRequest : ICreateRequest
{
    public string Name { get; set; }
}
