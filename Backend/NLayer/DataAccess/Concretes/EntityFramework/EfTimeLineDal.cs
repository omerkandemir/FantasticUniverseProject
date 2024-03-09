using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;
using NLAyer.Core.DataAccess.Concretes.EntityFramework;

namespace NLayer.DataAccess.Concretes.EntityFramework;

public class EfTimeLineDal : EfEntityRepositoryBase<TimeLine, FantasticUniverseProjectContext>, ITimeLineDal
{

}
