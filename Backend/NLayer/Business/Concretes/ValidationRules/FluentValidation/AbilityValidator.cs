using FluentValidation;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.ValidationRules.FluentValidation;

public class AbilityValidator : AbstractValidator<Ability>
{
    public AbilityValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Yetenek adı boş olamaz");
    }
}
