using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionCharacterValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionCharacterValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionCharacterValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UnionCharacterManager : BaseManagerAsync<UnionCharacter, IUnionCharacterDal>, IUnionCharacterService
{
    public UnionCharacterManager(IUnionCharacterDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateUnionCharacterValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(UnionCharacter value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateUnionCharacterValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(UnionCharacter value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteUnionCharacterValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(UnionCharacter value)
    {
        return base.DeleteAsync(value);
    }
}
