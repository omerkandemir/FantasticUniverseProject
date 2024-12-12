using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityCharacterValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityCharacterValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityCharacterValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AbilityCharacterManager : BaseManagerAsync<AbilityCharacter, IAbilityCharacterDal,int>, IAbilityCharacterService
{
    public AbilityCharacterManager(IAbilityCharacterDal tdal) : base(tdal)
    {

    }
    [ValidationAspect(typeof(CreateAbilityCharacterValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(AbilityCharacter value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateAbilityCharacterValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(AbilityCharacter value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteAbilityCharacterValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(AbilityCharacter value)
    {
        return base.DeleteAsync(value);
    }
}
