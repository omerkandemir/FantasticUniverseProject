using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.AdventureCharacter;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AdventureCharacterValidation.Delete;

public class DeleteAdventureCharacterValidator : BaseDeleteValidator<DeleteAdventureCharacterRequest>
{
    public DeleteAdventureCharacterValidator()
    {
        
    }
}
