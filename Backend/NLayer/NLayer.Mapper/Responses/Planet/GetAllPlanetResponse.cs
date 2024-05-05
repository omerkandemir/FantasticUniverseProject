using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Planet;

public class GetAllPlanetResponse : IGetResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int StarId { get; set; }
    public string Name { get; set; }
    public int PlanetAge { get; set; }
    public int PlanetTemperature { get; set; }
    public int PlanetMass { get; set; }

}
