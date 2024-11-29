using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class AdventureCollection : BaseEntity<int>
{
    public string Name { get; set; } // Koleksiyon ismi, örn. "Kayıp Krallığın Macerası"
    public ICollection<AdventureCollectionItem> AdventureCollectionItems { get; set; } // Koleksiyona ait maceralar
}
