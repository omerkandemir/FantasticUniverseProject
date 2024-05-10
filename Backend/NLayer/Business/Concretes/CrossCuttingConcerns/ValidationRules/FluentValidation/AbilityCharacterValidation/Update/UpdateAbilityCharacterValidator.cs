using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.AbilityCharacter;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityCharacterValidation.Update;

public class UpdateAbilityCharacterValidator : BaseUpdateValidator<UpdateAbilityCharacterRequest>
{
    public UpdateAbilityCharacterValidator()
    {
        RuleFor(x => new { AbilityId = x.AbilityId, CharacterId = x.CharacterId }).DoesAbilityCharacterPairExist();

        RuleFor(x => x.AbilityId).NotEmpty().WithMessage("Yetenek seçilmelidir.");
        RuleFor(x => x.AbilityId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.AbilityId).IsAbilityIdExists(false).WithMessage("Böyle bir yetenek kayıtlı değil.");

        RuleFor(x => x.CharacterId).NotEmpty().WithMessage("Karakter seçilmelidir.");
        RuleFor(x => x.CharacterId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.CharacterId).IsCharacterIdExists(false).WithMessage("Böyle bir karakter kayıtlı değil.");
    }
}
