using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UniverseManager : BaseManager<Universe, IUniverseDal>, IUniverseService
{
    public UniverseManager(IUniverseDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateUniverseValidator), Priority = 1)]
    public override IReturnType Add(Universe Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateUniverseValidator), Priority = 1)]
    public override IReturnType Update(Universe Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteUniverseValidator), Priority = 1)]
    public override IReturnType Delete(Universe Value)
    {
        return base.Delete(Value);
    }
}
