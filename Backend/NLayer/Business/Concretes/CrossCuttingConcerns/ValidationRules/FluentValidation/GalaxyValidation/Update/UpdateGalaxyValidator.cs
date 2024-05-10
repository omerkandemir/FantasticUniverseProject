using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Galaxy;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.GalaxyValidation.Update;

public class UpdateGalaxyValidator : BaseUpdateValidator<UpdateGalaxyRequest>
{
    public UpdateGalaxyValidator()
    {
        RuleFor(x => x.UniverseId).NotEmpty().WithMessage("Evren seçilmelidir.");
        RuleFor(x => x.UniverseId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.UniverseId).IsUniverseIdExists(false).WithMessage("Böyle bir evren kayıtlı değil.");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Galaksi adı boş olamaz.")
        .MinimumLength(2).WithMessage("Gezegen adı en az 2 karakterden oluşmalıdır.");
    }
}
