using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.PlanetValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Adventure;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation.Create;

public class CreateAdventureValidator : BaseCreateValidator<CreateAdventureRequest>
{
    public CreateAdventureValidator()
    {
        RuleFor(x => x.PlanetId).NotEmpty().WithMessage("Gezegen seçilmelidir.");
        RuleFor(x => x.PlanetId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.PlanetId).IsPlanetIdExists(false).WithMessage("Böyle bir gezegen kayıtlı değil.");

        RuleFor(x => x.AdventureName).NotEmpty().WithMessage("Macera adı boş olamaz.").
        MinimumLength(2).WithMessage("Macera adı en az 2 karakterden oluşmalıdır.");

        RuleFor(x => x.AdventureContent).NotEmpty().WithMessage("Macera içeriği boş olamaz.").
        MinimumLength(2).WithMessage("Macera içeriği en az 20 karakterden oluşmalıdır.");

        RuleFor(x => x.StartTime).NotEmpty().WithMessage("Başlangıç zamanı boş olamaz.");
        
        RuleFor(x => x.EndTime)
            .Must((model, endTime) => endTime > model.StartTime)
    .WithMessage("Bitiş zamanı, başlangıç zamanından sonra olmalıdır."); 
    }
}
