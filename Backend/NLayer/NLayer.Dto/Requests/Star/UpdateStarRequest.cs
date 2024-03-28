using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Star;

public class UpdateStarRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int GalaxyId { get; set; }
    public string Name { get; set; }
}
