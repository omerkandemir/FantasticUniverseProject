using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Star;

public class UpdatedStarResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int GalaxyId { get; set; }
    public string Name { get; set; }
}
