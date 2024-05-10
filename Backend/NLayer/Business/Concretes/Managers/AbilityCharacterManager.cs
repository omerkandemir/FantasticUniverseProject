using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityCharacterValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityCharacterValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityCharacterValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AbilityCharacterManager : BaseManager<AbilityCharacter, IAbilityCharacterDal>, IAbilityCharacterService
{
    public AbilityCharacterManager(IAbilityCharacterDal tdal) : base(tdal)
    {

    }
    [ValidationAspect(typeof(CreateAbilityCharacterValidator), Priority = 1)]
    public override IReturnType Add(AbilityCharacter Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateAbilityCharacterValidator), Priority = 1)]
    public override IReturnType Update(AbilityCharacter Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteAbilityCharacterValidator), Priority = 1)]
    public override IReturnType Delete(AbilityCharacter Value)
    {
        return base.Delete(Value);
    }
}
