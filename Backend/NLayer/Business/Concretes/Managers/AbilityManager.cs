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

public class AbilityManager : BaseManager<Ability, IAbilityDal>, IAbilityService
{
    public AbilityManager(IAbilityDal tdal) : base(tdal)
    {
    }
    [TransactionScopeAspect(Priority = 2)]
    [LogAspect(Priority = 3)]
    [ValidationAspect(typeof(CreateAbilityValidator), Priority = 1)]
    public override IReturnType Add(Ability Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateAbilityValidator), Priority = 1)]
    public override IReturnType Update(Ability Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteAbilityValidator), Priority = 1)]
    public override IReturnType Delete(Ability Value)
    {
        return base.Delete(Value);
    }

    [LogAspect] 
    public override IDataReturnType<List<Ability>> GetAll()
    {
        return base.GetAll();
    }
}