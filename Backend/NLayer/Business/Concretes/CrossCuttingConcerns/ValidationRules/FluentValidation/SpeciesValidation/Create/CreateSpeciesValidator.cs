using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Species;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.SpeciesValidation.Create;

public class CreateSpeciesValidator : BaseCreateValidator<CreateSpeciesRequest>
{
    public CreateSpeciesValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Tür adı boş olamaz.").
            MinimumLength(2).WithMessage("Tür adı en az 2 karakterden oluşmalıdır.");
    }
}
