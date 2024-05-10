using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureCharacterValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureCharacterValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureCharacterValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class AdventureCharacterManager : BaseManager<AdventureCharacter, IAdventureCharacterDal>, IAdventureCharacterService
{
    public AdventureCharacterManager(IAdventureCharacterDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateAdventureCharacterValidator), Priority = 1)]
    public override IReturnType Add(AdventureCharacter Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateAdventureCharacterValidator), Priority = 1)]
    public override IReturnType Update(AdventureCharacter Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteAdventureCharacterValidator), Priority = 1)]
    public override IReturnType Delete(AdventureCharacter Value)
    {
        return base.Delete(Value);
    }
}
