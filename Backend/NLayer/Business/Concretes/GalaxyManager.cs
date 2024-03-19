using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class GalaxyManager : BaseManager<Galaxy, IGalaxyDal>, IGalaxyService
{
    public GalaxyManager(IGalaxyDal tdal) : base(tdal)
    {
    }
}
