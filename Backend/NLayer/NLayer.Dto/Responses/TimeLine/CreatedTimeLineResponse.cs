using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.TimeLine;

public class CreatedTimeLineResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UniverseId { get; set; }
    public int StartingAdventureId { get; set; }
}
