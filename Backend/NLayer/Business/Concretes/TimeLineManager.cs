using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class TimeLineManager : ITimeLineService
{
    private readonly ITimeLineDal _timeLineDal;
    public TimeLineManager(ITimeLineDal timeLineDal)
    {
        _timeLineDal = timeLineDal;
    }
    public void Add(TimeLine timeLine)
    {
        _timeLineDal.Add(timeLine);
    }
    public void Update(TimeLine timeLine)
    {
        _timeLineDal.Update(timeLine);
    }
    public void Delete(TimeLine timeLine)
    {
        _timeLineDal.Delete(timeLine);
    }
    public TimeLine Get(int id)
    {
        return _timeLineDal.Get(x => x.Id == id);
    }
    public List<TimeLine> GetAll()
    {
        return _timeLineDal.GetAll();
    }
}
