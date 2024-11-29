using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.TimeLine;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.TimeLineValidation.Create;

public class CreateTimeLineValidator : BaseCreateValidator<CreateTimeLineRequest>
{
    public CreateTimeLineValidator()
    {
        RuleFor(x => x.StartingAdventureId).NotEmpty().WithMessage("Başlangıç Macerası seçilmelidir.");
        RuleFor(x => x.StartingAdventureId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.StartingAdventureId).IsAdventureIdExists(false).WithMessage("Böyle bir macera kayıtlı değil.");
    }
}
