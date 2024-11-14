namespace Test.PresentationLayer.Models.UniverseOperations;

public class StarViewModel
{
    public string Name { get; set; }
    public List<PlanetViewModel> Planets { get; set; } = new List<PlanetViewModel>();
}
