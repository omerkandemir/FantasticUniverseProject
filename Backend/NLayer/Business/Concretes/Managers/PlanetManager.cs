using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.PlanetValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.PlanetValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.PlanetValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class PlanetManager : BaseManagerAsync<Planet, IPlanetDal>, IPlanetService
{
    public PlanetManager(IPlanetDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreatePlanetValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(Planet value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdatePlanetValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(Planet value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeletePlanetValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(Planet value)
    {
        return base.DeleteAsync(value);
    }
}
