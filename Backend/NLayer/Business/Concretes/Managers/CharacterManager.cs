using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class CharacterManager : BaseManagerAsync<Character, ICharacterDal>, ICharacterService
{
    public CharacterManager(ICharacterDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateCharacterValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(Character value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateCharacterValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(Character value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteCharacterValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(Character value)
    {
        return base.DeleteAsync(value);
    }
}
