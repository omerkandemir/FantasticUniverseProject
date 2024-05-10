using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Species;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.SpeciesValidation.Update;

public class UpdateSpeciesValidator : BaseUpdateValidator<UpdateSpeciesRequest>
{
    public UpdateSpeciesValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Tür adı boş olamaz.").
            MinimumLength(2).WithMessage("Tür adı en az 2 karakterden oluşmalıdır.");
    }
}
