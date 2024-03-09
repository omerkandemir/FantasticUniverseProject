using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class Planet : BaseEntity<int>
{
    public int StarId { get; set; }
    public Star Star { get; set; }
    public string Name { get; set; }
    public int PlanetAge { get; set; }
    public int PlanetTemperature { get; set; }
    public int PlanetMass { get; set; }
    public ICollection<Adventure> Adventures { get; set; }
}
