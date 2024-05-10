using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Union;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UnionValidation.Create;

public class CreateUnionValidator : BaseCreateValidator<CreateUnionRequest>
{
    public CreateUnionValidator()
    {
        RuleFor(x => x.UniverseId).NotEmpty().WithMessage("Evren seçilmelidir.");
        RuleFor(x => x.UniverseId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.UniverseId).IsUniverseIdExists(false).WithMessage("Böyle bir evren kayıtlı değil.");

        RuleFor(x => x.UnionLeaderId).IsCharacterIdExists(true).WithMessage("Böyle bir karakter kayıtlı değil.");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Birlik adı boş olamaz.").
        MinimumLength(2).WithMessage("Birlik adı en az 2 karakterden oluşmalıdır.");

        RuleFor(x => x.Target).NotEmpty().WithMessage("Hedef adı boş olamaz.").
        MinimumLength(2).WithMessage("Hedef adı en az 2 karakterden oluşmalıdır.");
    }
}
