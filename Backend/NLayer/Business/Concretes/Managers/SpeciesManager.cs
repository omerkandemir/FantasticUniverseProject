using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.SpeciesValidation.Create;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.SpeciesValidation.Delete;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.SpeciesValidation.Update;
using NLayer.Core.Aspect.Autofac.Validation;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class SpeciesManager : BaseManagerAsync<Species, ISpeciesDal>, ISpeciesService
{
    public SpeciesManager(ISpeciesDal tdal) : base(tdal)
    {
    }
    [ValidationAspect(typeof(CreateSpeciesValidator), Priority = 1)]
    public override Task<IReturnType> AddAsync(Species value)
    {
        return base.AddAsync(value);
    }
    [ValidationAspect(typeof(UpdateSpeciesValidator), Priority = 1)]
    public override Task<IReturnType> UpdateAsync(Species value)
    {
        return base.UpdateAsync(value);
    }
    [ValidationAspect(typeof(DeleteSpeciesValidator), Priority = 1)]
    public override Task<IReturnType> DeleteAsync(Species value)
    {
        return base.DeleteAsync(value);
    }
}
