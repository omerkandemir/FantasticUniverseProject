using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AdventureCollectionManager : BaseManagerAsync<AdventureCollection, IAdventureCollectionDal>, IAdventureCollectionService
{
    public AdventureCollectionManager(IAdventureCollectionDal tdal) : base(tdal)
    {
    }

}
