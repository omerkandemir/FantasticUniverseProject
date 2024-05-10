using FluentValidation;
using NLayer.Core.Dto.Abstracts;

namespace NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;

public abstract class BaseDeleteValidator<T> : AbstractValidator<T> where T : class, IDeleteRequest, new()
{
    protected BaseDeleteValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(x => x.Id).NotEqual(0).WithMessage("Id 0'a eşit olamaz");
    }
}
