using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Adventure;

public class GetAdventureResponse : IGetAdventureResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int PlanetId { get; set; }
    public string AdventureName { get; set; }
    public string AdventureContent { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}
