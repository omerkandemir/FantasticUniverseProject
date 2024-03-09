using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Universe;

public class UpdatedUniverseResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Name { get; set; }
    public int TimeLineId { get; set; }
}
