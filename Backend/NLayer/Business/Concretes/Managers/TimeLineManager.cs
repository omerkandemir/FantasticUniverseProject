using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.TimeLineValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.TimeLineValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.TimeLineValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class TimeLineManager : BaseManager<TimeLine, ITimeLineDal>, ITimeLineService
{
    public TimeLineManager(ITimeLineDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateTimeLineValidator), Priority = 1)]
    public override IReturnType Add(TimeLine Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateTimeLineValidator), Priority = 1)]
    public override IReturnType Update(TimeLine Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteTimeLineValidator), Priority = 1)]
    public override IReturnType Delete(TimeLine Value)
    {
        return base.Delete(Value);
    }
}

