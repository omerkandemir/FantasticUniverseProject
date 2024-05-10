using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionCharacterValidation;

public static class CustomUnionCharacterValidator
{
    public static IRuleBuilderOptions<T, object> DoesUnionCharacterPairExist<T>(this IRuleBuilder<T, object> ruleBuilder)
    {
        return ruleBuilder.Must((rootObject, context) =>
        {
            var pair = (dynamic)rootObject;
            var unionCharacterService = InstanceFactory.GetInstance<IUnionCharacterService>();
            var pairExist = unionCharacterService.GetAll().Data.Any(p => p.UnionId == pair.UnionId && p.CharacterId == pair.CharacterId);
            return !pairExist;
        }).WithMessage("Belirtilen UnionId ve CharacterId çifti mevcut.");
    }
}
