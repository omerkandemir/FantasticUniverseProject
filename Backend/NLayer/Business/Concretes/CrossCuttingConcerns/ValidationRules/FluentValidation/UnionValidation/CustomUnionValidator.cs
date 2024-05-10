using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionValidation;

public static class CustomUnionValidator
{
    public static IRuleBuilderOptions<T, TProperty> IsUnionIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
    {
        var unionService = InstanceFactory.GetInstance<IUnionService>();
        var unions = unionService.GetAll().Data;

        return ruleBuilder.Must((rootObject, Id, context) =>
        {
            if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
            {
                return true; // Null değer kabul edilir.
            }
            return unions.Any(e => e.Id == (int)(object)Id); 
        }).WithMessage("Böyle bir birlik kayıtlı değil.");
    }
}
