using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UnionManager : BaseManagerAsync<Union, IUnionDal, int>, IUnionService
{
    public UnionManager(IUnionDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateUnionValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(Union value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateUnionValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(Union value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteUnionValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(Union value)
    {
        return base.DeleteAsync(value);
    }
}
