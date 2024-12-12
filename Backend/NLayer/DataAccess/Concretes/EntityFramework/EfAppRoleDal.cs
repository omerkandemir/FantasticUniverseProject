using NLAyer.Core.DataAccess.Concretes.EntityFramework;
using NLayer.DataAccess.Abstracts;
using NLayer.Core.Entities.Authorization;

namespace NLayer.DataAccess.Concretes.EntityFramework;

public class EfAppRoleDal : EfEntityRepositoryBase<AppRole, FantasticUniverseProjectContext>, IAppRoleDal
{
}
