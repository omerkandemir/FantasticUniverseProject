using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AdventureCollectionItemManager : BaseManagerAsync<AdventureCollectionItem, IAdventureCollectionItemDal, int>, IAdventureCollectionItemService
{
    public AdventureCollectionItemManager(IAdventureCollectionItemDal tdal) : base(tdal)
    {
    }
}
