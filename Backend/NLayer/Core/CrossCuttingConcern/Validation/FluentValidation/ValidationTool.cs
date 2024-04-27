using FluentValidation;

namespace NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
public class ValidationTool
{
    public static void FluentValidate(IValidator validator, object entity)
    {
        var result = validator.Validate((IValidationContext)entity);
        if (result.Errors.Count>0)
        {
            throw new ValidationException(result.Errors);
        }
    }
}
