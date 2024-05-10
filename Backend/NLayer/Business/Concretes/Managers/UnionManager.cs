using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UnionManager : BaseManager<Union, IUnionDal>, IUnionService
{
    public UnionManager(IUnionDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateUnionValidator), Priority = 1)]
    public override IReturnType Add(Union Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateUnionValidator), Priority = 1)]
    public override IReturnType Update(Union Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteUnionValidator), Priority = 1)]
    public override IReturnType Delete(Union Value)
    {
        return base.Delete(Value);
    }
}
