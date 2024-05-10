using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Ability;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityValidation.Create;

public class CreateAbilityValidator : BaseCreateValidator<CreateAbilityRequest>
{
    public CreateAbilityValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Yetenek adı boş olamaz.").
            MinimumLength(2).WithMessage("Yetenek adı en az 2 karakterden oluşmalıdır.");
    }
}
