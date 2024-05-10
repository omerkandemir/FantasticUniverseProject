﻿using FluentValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Universe;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation.Create;

public class CreateUniverseValidator : BaseCreateValidator<CreateUniverseRequest>
{
    public CreateUniverseValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Evren adı boş olamaz.").
            MinimumLength(2).WithMessage("Evren adı en az 2 karakterden oluşmalıdır.");
    }
}
