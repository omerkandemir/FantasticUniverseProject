using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.PlanetValidation;

public static class CustomPlanetValidator
{
    public static IRuleBuilderOptions<T, TProperty> IsPlanetIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
    {
        var planetService = InstanceFactory.GetInstance<IPlanetService>();
        return ruleBuilder.MustAsync(async(rootObject, Id, context) =>
        {
            var planets = (await planetService.GetAllAsync()).Data;
            if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
            {
                return true; // Null değer kabul edilir.
            }
            return planets.Any(e => e.Id == (int)(object)Id);
        }).WithMessage("Böyle bir gezegen kayıtlı değil.");
    }
}
