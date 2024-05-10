using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.SpeciesValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Character;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation.Update;

public class UpdateCharacterValidator : BaseUpdateValidator<UpdateCharacterRequest>
{
    public UpdateCharacterValidator()
    {
        RuleFor(x => x.SpeciesId).IsSpeciesIdExists(true).WithMessage("Böyle bir tür kayıtlı değil.");

        RuleFor(x => x.MasterCharacterId).IsCharacterIdExists(true).WithMessage("Böyle bir karakter kayıtlı değil.");
        RuleFor(x => x.ApprenticeId).IsCharacterIdExists(true).WithMessage("Böyle bir karakter kayıtlı değil.");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Karakter adı boş olamaz.").
        MinimumLength(2).WithMessage("Karakter adı en az 2 karakterden oluşmalıdır.");

        RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Doğum günü boş olamaz.");

        RuleFor(x => x.DeathDate)
            .Must((model, endTime) => endTime > model.BirthDate)
    .WithMessage("Ölüm günü, doğum gününden sonra olmalıdır.");
    }
}
