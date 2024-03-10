using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Universe;

public class UpdateUniverseRequest : IUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
