using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureCharacterValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureCharacterValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureCharacterValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AdventureCharacterManager : BaseManagerAsync<AdventureCharacter, IAdventureCharacterDal, int>, IAdventureCharacterService
{
    public AdventureCharacterManager(IAdventureCharacterDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateAdventureCharacterValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(AdventureCharacter value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateAdventureCharacterValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(AdventureCharacter value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteAdventureCharacterValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(AdventureCharacter value)
    {
        return base.DeleteAsync(value);
    }
}
