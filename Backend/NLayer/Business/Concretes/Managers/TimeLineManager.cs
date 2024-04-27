using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class TimeLineManager : BaseManager<TimeLine, ITimeLineDal>, ITimeLineService
{
    public TimeLineManager(ITimeLineDal tdal) : base(tdal)
    {
    }
}

