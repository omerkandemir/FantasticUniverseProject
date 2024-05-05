using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Planet;

public class UpdatePlanetRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int StarId { get; set; }
    public string Name { get; set; }
    public int PlanetAge { get; set; }
    public int PlanetTemperature { get; set; }
    public int PlanetMass { get; set; }
}
