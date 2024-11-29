using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionCharacterValidation;

public static class CustomUnionCharacterValidator
{
    public static IRuleBuilderOptions<T, object> DoesUnionCharacterPairExist<T>(this IRuleBuilder<T, object> ruleBuilder)
    {
        var unionCharacterService = InstanceFactory.GetInstance<IUnionCharacterService>();
        return ruleBuilder.MustAsync(async (rootObject, context) =>
        {
            var pair = (dynamic)rootObject;
            var pairExist = (await unionCharacterService.GetAllAsync()).Data.Any(p => p.UnionId == pair.UnionId && p.CharacterId == pair.CharacterId);
            return !pairExist;
        }).WithMessage("Belirtilen UnionId ve CharacterId çifti mevcut.");
    }
}
