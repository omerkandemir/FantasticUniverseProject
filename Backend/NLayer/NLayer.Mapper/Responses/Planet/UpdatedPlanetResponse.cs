using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Planet;

public class UpdatedPlanetResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int StarId { get; set; }
    public string Name { get; set; }
    public int PlanetAge { get; set; }
    public int PlanetTemperature { get; set; }
    public int PlanetMass { get; set; }
}
