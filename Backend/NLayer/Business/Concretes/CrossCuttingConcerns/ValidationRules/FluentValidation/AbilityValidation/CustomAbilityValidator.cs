﻿using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityValidation;

public static class CustomAbilityValidator
{
    public static IRuleBuilderOptions<T, TProperty> IsAbilityIdExists<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowNull)
    {
        var abilityService = InstanceFactory.GetInstance<IAbilityService>();
        return ruleBuilder.MustAsync(async (rootObject, Id, context) =>
        {
            var abilities = (await abilityService.GetAllAsync()).Data;
            if (allowNull && EqualityComparer<TProperty>.Default.Equals(Id, default))
            {
                return true;// Null değer kabul edilir.
            }
            return abilities.Any(e => e.Id == (int)(object)Id); 
        }).WithMessage("Böyle bir yetenek kayıtlı değil.");
    }
}
