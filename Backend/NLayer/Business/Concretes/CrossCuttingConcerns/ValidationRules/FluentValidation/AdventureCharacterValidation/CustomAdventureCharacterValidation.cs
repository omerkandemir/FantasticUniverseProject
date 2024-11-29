using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureCharacterValidation;

public static class CustomAdventureCharacterValidation
{
    public static IRuleBuilderOptions<T, object> DoesAdventureCharacterPairExist<T>(this IRuleBuilder<T, object> ruleBuilder)
    {
        return ruleBuilder.MustAsync(async (rootObject, context) =>
        {
            var pair = (dynamic)rootObject;
            var adventureCharacterService = InstanceFactory.GetInstance<IAdventureCharacterService>();
            var pairExist = (await adventureCharacterService.GetAllAsync()).Data.Any(p => p.AdventureId == pair.AdventureId && p.CharacterId == pair.CharacterId);
            return !pairExist;
        }).WithMessage("Belirtilen AdventureId ve CharacterId çifti mevcut.");
    }
}
