using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class ThemeSetting : BaseEntity<int>
{
    public BackgroundType Background { get; set; }
    public string FontFamily { get; set; }
    public string FontColorR { get; set; }
    public string FontColorG { get; set; }
    public string FontColorB { get; set; }
    public ICollection<Universe>? Universes { get; set; }
}
public enum BackgroundType
{
    Default,
    Stars,
    Galaxy,
    Night,
    Mist
}
