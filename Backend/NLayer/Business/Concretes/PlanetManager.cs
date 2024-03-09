using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Dto.Requests.Planet;
using NLayer.Dto.Responses.Planet;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class PlanetManager : IPlanetService
{
    private readonly IPlanetDal _planetDal;
    public PlanetManager(IPlanetDal planetDal)
    {
        _planetDal = planetDal;
    }
    public CreatedPlanetResponse Add(CreatePlanetRequest createRequest)
    {
        Planet planet = new();
        planet.StarId = createRequest.StarId;
        planet.Name = createRequest.Name;
        planet.PlanetAge = createRequest.PlanetAge;
        planet.PlanetTemperature = createRequest.PlanetTemperature;
        planet.PlanetMass = createRequest.PlanetMass;


        _planetDal.Add(planet);

        CreatedPlanetResponse createdPlanetResponse = new CreatedPlanetResponse();
        createdPlanetResponse.Id = planet.Id;
        createdPlanetResponse.StarId = planet.StarId;
        createdPlanetResponse.Name = planet.Name;
        createdPlanetResponse.PlanetAge = planet.PlanetAge;
        createdPlanetResponse.PlanetTemperature = planet.PlanetTemperature;
        createdPlanetResponse.PlanetMass = planet.PlanetMass;

        return createdPlanetResponse;
    }

    public DeletedPlanetResponse Delete(DeletePlanetRequest deleteRequest)
    {
        Planet planet = new() { Id = deleteRequest.Id };
        _planetDal.Delete(planet);
        DeletedPlanetResponse deletedPlanetResponse = new DeletedPlanetResponse();
        deletedPlanetResponse.Id = planet.Id;
        return deletedPlanetResponse;
    }

    public GetAllPlanetResponse Get(int id)
    {
        GetAllPlanetResponse getAllPlanetResponse = new GetAllPlanetResponse();
        Planet planet = _planetDal.Get(x => x.Id == id);
        getAllPlanetResponse.Id = planet.Id;
        getAllPlanetResponse.StarId = planet.StarId;
        getAllPlanetResponse.Name = planet.Name;
        getAllPlanetResponse.PlanetAge = planet.PlanetAge;
        getAllPlanetResponse.PlanetTemperature = planet.PlanetTemperature;
        getAllPlanetResponse.PlanetMass = planet.PlanetMass;
        getAllPlanetResponse.CreatedDate = planet.CreatedDate;
        return getAllPlanetResponse;
    }

    public List<GetAllPlanetResponse> GetAll()
    {
        List<Planet> planets = _planetDal.GetAll();

        List<GetAllPlanetResponse> getAllPlanetResponses = new List<GetAllPlanetResponse>();

        foreach (var planet in planets)
        {
            GetAllPlanetResponse getAllPlanetResponse = new GetAllPlanetResponse();
            getAllPlanetResponse.Id = planet.Id;
            getAllPlanetResponse.StarId = planet.StarId;
            getAllPlanetResponse.Name = planet.Name;
            getAllPlanetResponse.PlanetAge = planet.PlanetAge;
            getAllPlanetResponse.PlanetTemperature = planet.PlanetTemperature;
            getAllPlanetResponse.PlanetMass = planet.PlanetMass;
            getAllPlanetResponse.CreatedDate = planet.CreatedDate;

            getAllPlanetResponses.Add(getAllPlanetResponse);
        }
        return getAllPlanetResponses;
    }

    public UpdatedPlanetResponse Update(UpdatePlanetRequest updateRequest)
    {
        Planet planet = new();
        planet.Id = updateRequest.Id;
        planet.StarId = updateRequest.StarId;
        planet.Name = updateRequest.Name;
        planet.PlanetAge = updateRequest.PlanetAge;
        planet.PlanetTemperature = updateRequest.PlanetTemperature;
        planet.PlanetMass = updateRequest.PlanetMass;

        _planetDal.Update(planet);

        UpdatedPlanetResponse updatedPlanetResponse = new UpdatedPlanetResponse();
        updatedPlanetResponse.Id = planet.Id;
        updatedPlanetResponse.StarId = planet.StarId;
        updatedPlanetResponse.Name = planet.Name;
        updatedPlanetResponse.PlanetAge = planet.PlanetAge;
        updatedPlanetResponse.PlanetTemperature = planet.PlanetTemperature;
        updatedPlanetResponse.PlanetMass = planet.PlanetMass;
        updatedPlanetResponse.UpdatedDate = planet.UpdatedDate;
        return updatedPlanetResponse;
    }
}
