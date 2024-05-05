using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Galaxy;

public class UpdateGalaxyRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int UniverseId { get; set; }
    public string Name { get; set; }
}
