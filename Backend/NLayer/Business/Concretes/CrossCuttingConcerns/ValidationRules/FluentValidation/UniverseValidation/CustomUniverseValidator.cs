using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation
{
    public static class CustomUniverseValidator
    {
        public static IRuleBuilderOptions<T, TProperty> IsUniverseIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
        {
            var universeService = InstanceFactory.GetInstance<IUniverseService>();
            var universes = universeService.GetAll().Data;
            return ruleBuilder.Must((rootObject, Id, context) =>
            {
                if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
                {
                    return true; // Null değer kabul edilir.
                }
                return universes.Any(e => e.Id == (int)(object)Id); 
            }).WithMessage("Böyle bir evren kayıtlı değil.");
        }
    }
}
