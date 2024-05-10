using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.UnionCharacter;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionCharacterValidation.Create;

public class CreateUnionCharacterValidator : BaseCreateValidator<CreateUnionCharacterRequest>
{
    public CreateUnionCharacterValidator()
    {
        RuleFor(x => new { UnionId = x.UnionId, CharacterId = x.CharacterId }).DoesUnionCharacterPairExist();

        RuleFor(x => x.UnionId).NotEmpty().WithMessage("Birlik seçilmelidir.");
        RuleFor(x => x.UnionId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.UnionId).IsUnionIdExists(false).WithMessage("Böyle bir birlik kayıtlı değil.");

        RuleFor(x => x.CharacterId).NotEmpty().WithMessage("Karakter seçilmelidir.");
        RuleFor(x => x.CharacterId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.CharacterId).IsCharacterIdExists(false).WithMessage("Böyle bir karakter kayıtlı değil.");
    }
}
