using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Galaxy;

public class CreateGalaxyRequest : ICreateRequest
{
    public int UniverseId { get; set; }
    public string Name { get; set; }

}
