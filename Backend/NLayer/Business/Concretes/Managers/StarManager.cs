using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.StarValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.StarValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.StarValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class StarManager : BaseManagerAsync<Star, IStarDal, int>, IStarService
{
    public StarManager(IStarDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateStarValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(Star value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateStarValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(Star value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteStarValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(Star value)
    {
        return base.DeleteAsync(value);
    }
}
