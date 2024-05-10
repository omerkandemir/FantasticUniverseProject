using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityCharacterValidation;

public static class CustomAbilityCharacterValidation
{
    public static IRuleBuilderOptions<T, object> DoesAbilityCharacterPairExist<T>(this IRuleBuilder<T, object> ruleBuilder)
    {
        return ruleBuilder.Must((rootObject, context) =>
        {
            var pair = (dynamic)rootObject;
            var abilityCharacterService = InstanceFactory.GetInstance<IAbilityCharacterService>();
            var pairExist = abilityCharacterService.GetAll().Data.Any(p => p.AbilityId == pair.AbilityId && p.CharacterId == pair.CharacterId);
            return !pairExist;
        }).WithMessage("Belirtilen AbilityId ve CharacterId çifti mevcut.");
    }
}
