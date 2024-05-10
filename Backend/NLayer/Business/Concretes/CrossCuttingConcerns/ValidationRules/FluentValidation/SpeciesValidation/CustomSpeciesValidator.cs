using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.SpeciesValidation;

public static class CustomSpeciesValidator
{    
    public static IRuleBuilderOptions<T, TProperty> IsSpeciesIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
    {
        var speciesService = InstanceFactory.GetInstance<ISpeciesService>();
        var species = speciesService.GetAll().Data;

        return ruleBuilder.Must((rootObject, Id, context) =>
        {
            if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
            {
                return true; // Null değer kabul edilir.
            }
            return species.Any(e => e.Id == (int)(object)Id); 
        }).WithMessage("Böyle bir tür kayıtlı değil.");
    }
}
