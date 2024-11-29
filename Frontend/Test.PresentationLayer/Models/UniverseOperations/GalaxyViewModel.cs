namespace Test.PresentationLayer.Models.UniverseOperations;

public class GalaxyViewModel
{
    public string Name { get; set; }
    public List<StarViewModel> Stars { get; set; } = new List<StarViewModel>();
}
