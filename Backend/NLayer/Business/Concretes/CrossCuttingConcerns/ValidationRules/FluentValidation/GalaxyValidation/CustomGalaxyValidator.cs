using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.GalaxyValidation;

public static class CustomGalaxyValidator
{
    public static IRuleBuilderOptions<T, TProperty> IsGalaxyIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
    {
        var galaxyService = InstanceFactory.GetInstance<IGalaxyService>();
        return ruleBuilder.MustAsync(async(rootObject, Id, context) =>
        {
            var galaxies = (await galaxyService.GetAllAsync()).Data;
            if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
            {
                return true; // Null değer kabul edilir.
            }
            return galaxies.Any(e => e.Id == (int)(object)Id); 
        }).WithMessage("Böyle bir galaksi kayıtlı değil.");
    }
}
