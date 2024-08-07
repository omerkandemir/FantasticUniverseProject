﻿using FluentValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseValidation;
using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.TimeLine;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.TimeLineValidation.Update;

public class UpdateTimeLineValidator : BaseUpdateValidator<UpdateTimeLineRequest>
{
    public UpdateTimeLineValidator()
    {
        RuleFor(x => x.StartingAdventureId).NotEmpty().WithMessage("Başlangıç Macerası seçilmelidir.");
        RuleFor(x => x.StartingAdventureId).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
        RuleFor(x => x.StartingAdventureId).IsAdventureIdExists(false).WithMessage("Böyle bir macera kayıtlı değil.");
    }
}
