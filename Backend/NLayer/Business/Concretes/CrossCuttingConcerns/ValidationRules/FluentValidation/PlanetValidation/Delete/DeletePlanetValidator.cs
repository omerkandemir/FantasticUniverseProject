using NLayer.Core.CrossCuttingConcern.Validation.FluentValidation;
using NLayer.Mapper.Requests.Planet;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.PlanetValidation.Delete;

public class DeletePlanetValidator : BaseDeleteValidator<DeletePlanetRequest>
{
    public DeletePlanetValidator()
    {
        
    }
}
