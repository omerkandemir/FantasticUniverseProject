using FluentValidation;
using NLayer.Mapper.Requests.Ability;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation;

public class CreateAbilityValidator : AbstractValidator<CreateAbilityRequest>
{
    public CreateAbilityValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Yetenek adı boş olamaz");
        RuleFor(x => x.Name).Must(StartWithA).WithMessage("A ile başlamalıdır.");
    }

    private bool StartWithA(string arg)
    {
        return arg.StartsWith('A');
    }
}
