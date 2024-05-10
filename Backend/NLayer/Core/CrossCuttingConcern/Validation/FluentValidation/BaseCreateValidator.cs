using FluentValidation;
using NLayer.Core.Dto.Abstracts;

namespace NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;

public abstract class BaseCreateValidator<T> : AbstractValidator<T> where T : class, ICreateRequest, new()
{
    protected BaseCreateValidator()
    {
        
    }
}
