using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation;

public static class CustomAdventureValidator
{
    public static IRuleBuilderOptions<T, TProperty> IsAdventureIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
    {
        var adventureService = InstanceFactory.GetInstance<IAdventureService>();
        var adventures = adventureService.GetAll().Data;

        return ruleBuilder.Must((rootObject, Id, context) =>
        {
            if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
            {
                return true; // Null değer kabul edilir.
            }
            return adventures.Any(e => e.Id == (int)(object)Id); 
        }).WithMessage("Böyle bir macera kayıtlı değil.");
    }
}
