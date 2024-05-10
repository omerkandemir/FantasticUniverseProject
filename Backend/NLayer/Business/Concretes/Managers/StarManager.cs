using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.StarValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.StarValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.StarValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class StarManager : BaseManager<Star, IStarDal>, IStarService
{
    public StarManager(IStarDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateStarValidator), Priority = 1)]
    public override IReturnType Add(Star Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateStarValidator), Priority = 1)]
    public override IReturnType Update(Star Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteStarValidator), Priority = 1)]
    public override IReturnType Delete(Star Value)
    {
        return base.Delete(Value);
    }
}
