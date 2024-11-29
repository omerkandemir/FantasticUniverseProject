using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class AdventureCollectionItem : BaseEntity<int>
{
    public int AdventureCollectionId { get; set; } // Koleksiyon bağlantısı
    public AdventureCollection AdventureCollection { get; set; } // Koleksiyona bağlı olduğu sınıf
    public int AdventureId { get; set; } // Temsil ettiği macera
    public Adventure Adventure { get; set; }
    public int? OrderIndex { get; set; } // Sıralı hikaye için
    public int? NextAdventureId { get; set; } // Standart sıradaki macera
    public AdventureCollectionItem NextAdventure { get; set; } // Self-referencing property
    public ICollection<AdventureAlternativePaths> AlternativePaths { get; set; } // Alternatif yollar
}
