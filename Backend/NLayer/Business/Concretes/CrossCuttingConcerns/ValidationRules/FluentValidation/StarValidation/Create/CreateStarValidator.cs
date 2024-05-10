using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.GalaxyValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Star;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.StarValidation.Create;

public class CreateStarValidator : BaseCreateValidator<CreateStarRequest>
{
    public CreateStarValidator()
    {
        RuleFor(x => x.GalaxyId).NotEmpty().WithMessage("Galaksi seçilmelidir.");
        RuleFor(x => x.GalaxyId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.GalaxyId).IsGalaxyIdExists(false).WithMessage("Böyle bir galaksi kayıtlı değil.");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Yıldız adı boş olamaz.").
    MinimumLength(2).WithMessage("Yıldız adı en az 2 karakterden oluşmalıdır.");
    }
}
