using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Character;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.CharacterValidation.Delete;

public class DeleteCharacterValidator : BaseDeleteValidator<DeleteCharacterRequest>
{
    public DeleteCharacterValidator()
    {
        
    }
}
