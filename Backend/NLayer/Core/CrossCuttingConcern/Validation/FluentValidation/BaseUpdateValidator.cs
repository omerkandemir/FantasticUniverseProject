using FluentValidation;
using NLayer.Core.Dto.Abstracts;

namespace NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;

public abstract class BaseUpdateValidator<T> : AbstractValidator<T> where T : class, IUpdateRequest, new()
{
    protected BaseUpdateValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(x => x.Id).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
    }
}
