using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.TimeLine;

public class UpdatedTimeLineResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int UniverseId { get; set; }
    public int StartingAdventureId { get; set; }
}
