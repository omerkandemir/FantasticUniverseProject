using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class AdventureAlternativePaths : BaseEntity<int>
{
    public int AdventureCollectionItemId { get; set; } // Foreign key for the adventure collection item
    public AdventureCollectionItem AdventureCollectionItem { get; set; }

    public string Choice { get; set; } // Kullanıcının seçim yapabileceği alternatif (örn: "left", "right", "up")
    public int NextAdventureId { get; set; } // Seçim yapıldığında gidilecek macera ID’si
    public AdventureCollectionItem NextAdventure { get; set; } // Self-referencing property
}
