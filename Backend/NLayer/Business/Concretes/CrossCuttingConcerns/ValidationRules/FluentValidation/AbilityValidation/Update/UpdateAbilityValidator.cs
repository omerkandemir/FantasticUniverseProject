using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Ability;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityValidation.Update;

public class UpdateAbilityValidator : BaseUpdateValidator<UpdateAbilityRequest>
{
    public UpdateAbilityValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Yetenek adı boş olamaz").
             MinimumLength(2).WithMessage("Yetenek en az 2 karakterden oluşmalı");
    }
}
