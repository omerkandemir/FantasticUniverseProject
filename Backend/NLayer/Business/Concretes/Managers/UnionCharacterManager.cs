using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionCharacterValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionCharacterValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionCharacterValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UnionCharacterManager : BaseManager<UnionCharacter, IUnionCharacterDal>, IUnionCharacterService
{
    public UnionCharacterManager(IUnionCharacterDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateUnionCharacterValidator), Priority = 1)]
    public override IReturnType Add(UnionCharacter Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateUnionCharacterValidator), Priority = 1)]
    public override IReturnType Update(UnionCharacter Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteUnionCharacterValidator), Priority = 1)]
    public override IReturnType Delete(UnionCharacter Value)
    {
        return base.Delete(Value);
    }
}
