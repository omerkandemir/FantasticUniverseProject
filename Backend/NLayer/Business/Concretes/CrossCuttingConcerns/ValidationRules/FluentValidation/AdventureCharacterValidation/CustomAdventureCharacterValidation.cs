using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureCharacterValidation;

public static class CustomAdventureCharacterValidation
{
    public static IRuleBuilderOptions<T, object> DoesAdventureCharacterPairExist<T>(this IRuleBuilder<T, object> ruleBuilder)
    {
        return ruleBuilder.Must((rootObject, context) =>
        {
            var pair = (dynamic)rootObject;
            var adventureCharacterService = InstanceFactory.GetInstance<IAdventureCharacterService>();
            var pairExist = adventureCharacterService.GetAll().Data.Any(p => p.AdventureId == pair.AdventureId && p.CharacterId == pair.CharacterId);
            return !pairExist;
        }).WithMessage("Belirtilen AdventureId ve CharacterId çifti mevcut.");
    }
}
