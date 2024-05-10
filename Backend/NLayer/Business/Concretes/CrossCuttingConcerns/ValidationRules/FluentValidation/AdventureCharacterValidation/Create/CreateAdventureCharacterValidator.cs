using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.AdventureCharacter;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureCharacterValidation.Create;

public class CreateAdventureCharacterValidator : BaseCreateValidator<CreateAdventureCharacterRequest>
{
    public CreateAdventureCharacterValidator()
    {
        RuleFor(x => new { AdventureId = x.AdventureId, CharacterId = x.CharacterId }).DoesAdventureCharacterPairExist();

        RuleFor(x => x.AdventureId).NotEmpty().WithMessage("Macera seçilmelidir.");
        RuleFor(x => x.AdventureId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.AdventureId).IsAdventureIdExists(false).WithMessage("Böyle bir macera kayıtlı değil.");

        RuleFor(x => x.CharacterId).NotEmpty().WithMessage("Karakter seçilmelidir.");
        RuleFor(x => x.CharacterId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.CharacterId).IsCharacterIdExists(false).WithMessage("Böyle bir karakter kayıtlı değil.");
    }
}
