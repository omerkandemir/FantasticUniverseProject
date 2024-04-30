using FluentValidation;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation;

public class AbilityValidator : AbstractValidator<Ability>
{
    public AbilityValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Yetenek adı boş olamaz");
        RuleFor(x => x.Name).Must(StartWithA).WithMessage("A ile başlamalıdır.");
    }

    private bool StartWithA(string arg)
    {
        return arg.StartsWith('A');
    }
}
