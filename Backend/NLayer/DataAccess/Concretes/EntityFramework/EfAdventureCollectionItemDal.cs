using NLAyer.Core.DataAccess.Concretes.EntityFramework;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework;

public class EfAdventureCollectionItemDal : EfEntityRepositoryBase<AdventureCollectionItem, FantasticUniverseProjectContext>, IAdventureCollectionItemDal
{
}
