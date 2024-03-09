using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Star;

public class UpdatedStarResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int GalaxyId { get; set; }
    public string Name { get; set; }
}
