using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class StarManager : BaseManager<Star, IStarDal>, IStarService
{
    public StarManager(IStarDal tdal) : base(tdal)
    {
    }
}
