using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Adventure;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureValidation.Delete;

public class DeleteAdventureValidator : BaseDeleteValidator<DeleteAdventureRequest>
{
    public DeleteAdventureValidator()
    {
        
    }
}
