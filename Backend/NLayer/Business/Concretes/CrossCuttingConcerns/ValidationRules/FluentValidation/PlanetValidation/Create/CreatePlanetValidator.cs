using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.StarValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Planet;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.PlanetValidation.Create;

public class CreatePlanetValidator : BaseCreateValidator<CreatePlanetRequest>
{
    public CreatePlanetValidator()
    {
        RuleFor(x => x.StarId).NotEmpty().WithMessage("Yıldız seçilmelidir.");
        RuleFor(x => x.StarId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.StarId).IsStarIdExists(false).WithMessage("Böyle bir yıldız kayıtlı değil.");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Gezegen adı boş olamaz.")
         .MinimumLength(2).WithMessage("Gezegen adı en az 2 karakterden oluşmalıdır.");

        RuleFor(x => x.PlanetAge).NotEmpty().WithMessage("Gezegen yaşı boş olamaz.")
        .Must(x => int.TryParse(x.ToString(), out _)).WithMessage("Gezegen yaşı sadece sayı olmalıdır.");

        RuleFor(x => x.PlanetTemperature).NotEmpty().WithMessage("Gezegen sıcaklığı boş olamaz.")
       .Must(x => int.TryParse(x.ToString(), out _)).WithMessage("Gezegen sıcaklığı sadece sayı olmalıdır.");

        RuleFor(x => x.PlanetMass).NotEmpty().WithMessage("Gezegen kütlesi boş olamaz.")
       .Must(x => int.TryParse(x.ToString(), out _)).WithMessage("Gezegen kütlesi sadece sayı olmalıdır.");
    }
}
