using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityValidation.Update;
using NLayer.Core.Aspect.Autofac.Logging;
using NLayer.Core.Aspect.Autofac.Transaction;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AbilityManager : BaseManagerAsync<Ability, IAbilityDal>, IAbilityService
{
    public AbilityManager(IAbilityDal tdal) : base(tdal)
    {
    }
    [LogAspect(Priority = 3)]
    [ValidationAspect(typeof(CreateAbilityValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(Ability value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateAbilityValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(Ability value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteAbilityValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(Ability value)
    {
        return base.DeleteAsync(value);
    }

    [LogAspect]
    public override Task<IDataReturnType<ICollection<Ability>>> GetAllAsync()
    {
        return base.GetAllAsync();
    }
}