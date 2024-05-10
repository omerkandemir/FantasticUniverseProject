using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.PlanetValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.PlanetValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.PlanetValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class PlanetManager : BaseManager<Planet, IPlanetDal>, IPlanetService
{
    public PlanetManager(IPlanetDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreatePlanetValidator), Priority = 1)]
    public override IReturnType Add(Planet Value)
    {
        return base.Add(Value);
    }
    [ValidationAspect(typeof(UpdatePlanetValidator), Priority = 1)]
    public override IReturnType Update(Planet Value)
    {
        return base.Update(Value);
    }
    [ValidationAspect(typeof(DeletePlanetValidator), Priority = 1)]
    public override IReturnType Delete(Planet Value)
    {
        return base.Delete(Value);
    }
}
