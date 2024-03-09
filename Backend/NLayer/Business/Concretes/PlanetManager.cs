using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Planet;
using NLayer.Dto.Responses.Planet;

namespace NLayer.Business.Concretes;

public class PlanetManager : IPlanetService
{
    public CreatedPlanetResponse Add(CreatePlanetRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public DeletedPlanetResponse Delete(DeletePlanetRequest deleteRequest)
    {
        throw new NotImplementedException();
    }

    public GetAllPlanetResponse Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<GetAllPlanetResponse> GetAll()
    {
        throw new NotImplementedException();
    }

    public UpdatedPlanetResponse Update(UpdatePlanetRequest updateRequest)
    {
        throw new NotImplementedException();
    }
}
