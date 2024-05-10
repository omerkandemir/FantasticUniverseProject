using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Species;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.SpeciesValidation.Delete;

public class DeleteSpeciesValidator : BaseDeleteValidator<DeleteSpeciesRequest>
{
    public DeleteSpeciesValidator()
    {
        
    }
}
