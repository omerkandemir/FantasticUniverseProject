using NLayer.Entities.Concretes;

namespace Test.PresentationLayer.Models.UniverseOperations;

public class CreateUniverseViewModel
{
    public string UniverseName { get; set; }
    public ThemeSetting ThemeSetting { get; set; }
    public List<GalaxyViewModel> Galaxies { get; set; } = new List<GalaxyViewModel>();
}
