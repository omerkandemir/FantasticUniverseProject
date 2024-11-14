using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.GalaxyValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.GalaxyValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.GalaxyValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class GalaxyManager : BaseManagerAsync<Galaxy, IGalaxyDal>, IGalaxyService
{
    public GalaxyManager(IGalaxyDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateGalaxyValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(Galaxy value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateGalaxyValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(Galaxy value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteGalaxyValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(Galaxy value)
    {
        return base.DeleteAsync(value);
    }
}
