using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class Adventure : BaseEntity<int>
{
    public int PlanetId { get; set; }
    public Planet Planet { get; set; }
    public string AdventureName { get; set; }
    public string AdventureContent { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public ICollection<TimeLine> TimeLines { get; set; }
    public ICollection<AdventureCharacter> AdventureCharacters { get; set; }
    public ICollection<AdventureCollectionItem> AdventureCollectionItems { get; set; } // Koleksiyon bağlantısı
}
