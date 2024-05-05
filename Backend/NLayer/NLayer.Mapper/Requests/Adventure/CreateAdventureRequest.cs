using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Adventure;

public class CreateAdventureRequest : ICreateRequest
{
    public int PlanetId { get; set; }
    public string AdventureName { get; set; }
    public string Occurrence { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}
