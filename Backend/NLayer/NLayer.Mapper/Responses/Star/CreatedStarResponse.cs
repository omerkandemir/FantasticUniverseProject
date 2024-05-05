using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Star;

public class CreatedStarResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int GalaxyId { get; set; }
    public string Name { get; set; }
}
