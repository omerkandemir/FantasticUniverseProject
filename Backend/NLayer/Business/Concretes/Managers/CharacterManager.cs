using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class CharacterManager : BaseManager<Character, ICharacterDal>, ICharacterService
{
    public CharacterManager(ICharacterDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateCharacterValidator), Priority = 1)]
    public override IReturnType Add(Character Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateCharacterValidator), Priority = 1)]
    public override IReturnType Update(Character Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteCharacterValidator), Priority = 1)]
    public override IReturnType Delete(Character Value)
    {
        return base.Delete(Value);
    }
}
