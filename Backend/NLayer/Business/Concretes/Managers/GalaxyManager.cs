using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.GalaxyValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.GalaxyValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.GalaxyValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class GalaxyManager : BaseManager<Galaxy, IGalaxyDal>, IGalaxyService
{
    public GalaxyManager(IGalaxyDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateGalaxyValidator), Priority = 1)]
    public override IReturnType Add(Galaxy Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdateGalaxyValidator), Priority = 1)]
    public override IReturnType Update(Galaxy Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeleteGalaxyValidator), Priority = 1)]
    public override IReturnType Delete(Galaxy Value)
    {
        return base.Delete(Value);
    }
}
