using FluentValidation;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.ValidationRules.FluentValidation;

public class AbilityValidator : AbstractValidator<Ability>
{
    public AbilityValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.CreatedDate).GreaterThan(DateTime.MinValue);
        RuleFor(x => x.Name).NotEmpty().WithMessage("Yetenek adı boş olamaz");
        RuleFor(x=>x.Name).Must(StartWithA);
    }

    private bool StartWithA(string arg)
    {
        return arg.StartsWith('A');
    }
}
