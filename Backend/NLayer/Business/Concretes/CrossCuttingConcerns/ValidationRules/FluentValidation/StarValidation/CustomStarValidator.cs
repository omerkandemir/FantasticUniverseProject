﻿using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.StarValidation;

public static class CustomStarValidator
{
    public static IRuleBuilderOptions<T, TProperty> IsStarIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
    {
        var starService = InstanceFactory.GetInstance<IStarService>();
        var stars = starService.GetAll().Data;
        return ruleBuilder.Must((rootObject, Id, context) =>
        {
            if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
            {
                return true; // Null değer kabul edilir.
            }
            return stars.Any(e => e.Id == (int)(object)Id); 
        }).WithMessage("Böyle bir yıldız kayıtlı değil.");
    }
}
