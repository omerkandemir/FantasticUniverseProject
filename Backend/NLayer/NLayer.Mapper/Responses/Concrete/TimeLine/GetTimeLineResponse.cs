using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.TimeLine;

public class GetTimeLineResponse : IGetTimeLineResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UniverseId { get; set; }
    public int StartingAdventureId { get; set; }
}
