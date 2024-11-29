using NLAyer.Core.DataAccess.Concretes.EntityFramework;
using NLayer.DataAccess.Abstracts;
using NLayer.Core.Entities.Authentication;

namespace NLayer.DataAccess.Concretes.EntityFramework;

public class EfAppUserDal : EfEntityRepositoryBase<AppUser, FantasticUniverseProjectContext>, IAppUserDal
{
}
