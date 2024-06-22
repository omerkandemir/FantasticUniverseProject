using NLAyer.Core.DataAccess.Concretes.EntityFramework;
using NLayer.DataAccess.Abstracts;
using NLayer.Core.Entities.Concrete;

namespace NLayer.DataAccess.Concretes.EntityFramework;

public class EfUserImageDal : EfEntityRepositoryBase<UserImage, FantasticUniverseProjectContext>, IUserImageDal
{
}
