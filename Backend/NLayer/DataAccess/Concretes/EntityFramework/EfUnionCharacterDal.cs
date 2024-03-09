using NLAyer.Core.DataAccess.Concretes.EntityFramework;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework;

public class EfUnionCharacterDal : EfEntityRepositoryBase<UnionCharacter, FantasticUniverseProjectContext>, IUnionCharacterDal
{
}
