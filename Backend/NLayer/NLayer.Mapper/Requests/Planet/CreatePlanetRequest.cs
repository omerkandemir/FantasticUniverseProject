using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Planet;

public class CreatePlanetRequest : ICreateRequest
{
    public int StarId { get; set; }
    public string Name { get; set; }
    public int PlanetAge { get; set; }
    public int PlanetTemperature { get; set; }
    public int PlanetMass { get; set; }

}
