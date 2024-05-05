using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Universe;

public class UpdateUniverseRequest : IUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
