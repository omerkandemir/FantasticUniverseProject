using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.TimeLine;

public class UpdateTimeLineRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int UniverseId { get; set; }
    public int StartingAdventureId { get; set; }
}
