using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Ability;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AbilityValidation.Delete;

public class DeleteAbilityValidator : BaseDeleteValidator<DeleteAbilityRequest>
{
    public DeleteAbilityValidator()
    {
        
    }
}
