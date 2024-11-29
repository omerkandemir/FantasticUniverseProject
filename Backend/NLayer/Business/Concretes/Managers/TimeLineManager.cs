using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.TimeLineValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.TimeLineValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.TimeLineValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class TimeLineManager : BaseManagerAsync<TimeLine, ITimeLineDal>, ITimeLineService
{
    public TimeLineManager(ITimeLineDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateTimeLineValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(TimeLine value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateTimeLineValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(TimeLine value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteTimeLineValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(TimeLine value)
    {
        return base.DeleteAsync(value);
    }
}

