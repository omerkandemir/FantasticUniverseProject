using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Planet;

public class GetPlanetResponse : IGetPlanetResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int StarId { get; set; }
    public string Name { get; set; }
    public int PlanetAge { get; set; }
    public int PlanetTemperature { get; set; }
    public int PlanetMass { get; set; }
}
