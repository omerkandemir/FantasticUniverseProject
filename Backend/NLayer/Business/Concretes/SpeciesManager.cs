using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Dto.Requests.Species;
using NLayer.Dto.Responses.Species;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class SpeciesManager : ISpeciesService
{
    private readonly ISpeciesDal _speciesDal;
    public SpeciesManager(ISpeciesDal speciesDal)
    {
        _speciesDal = speciesDal;
    }
    public CreatedSpeciesResponse Add(CreateSpeciesRequest createRequest)
    {
        Species species = new();
        species.Name = createRequest.Name;

        _speciesDal.Add(species);

        CreatedSpeciesResponse createdSpeciesResponse = new CreatedSpeciesResponse();
        createdSpeciesResponse.Id = species.Id;
        createdSpeciesResponse.Name = species.Name;
        
        return createdSpeciesResponse;
    }

    public DeletedSpeciesResponse Delete(DeleteSpeciesRequest deleteRequest)
    {
        Species species = new() { Id = deleteRequest.Id };
        _speciesDal.Delete(species);
        DeletedSpeciesResponse deletedSpeciesResponse = new DeletedSpeciesResponse();
        deletedSpeciesResponse.Id = species.Id;
        return deletedSpeciesResponse;
    }

    public GetAllSpeciesResponse Get(int id)
    {
        GetAllSpeciesResponse getAllSpeciesResponse = new GetAllSpeciesResponse();
        Species species = _speciesDal.Get(x => x.Id == id);
        getAllSpeciesResponse.Id = species.Id;
        getAllSpeciesResponse.Name = species.Name;
        getAllSpeciesResponse.CreatedDate = species.CreatedDate;
        return getAllSpeciesResponse;
    }

    public List<GetAllSpeciesResponse> GetAll()
    {
        List<Species> species = _speciesDal.GetAll();

        List<GetAllSpeciesResponse> getAllSpeciesResponses = new List<GetAllSpeciesResponse>();

        foreach (var speciesentity in species)
        {
            GetAllSpeciesResponse getAllSpeciesResponse = new GetAllSpeciesResponse();
            getAllSpeciesResponse.Id = speciesentity.Id;
            getAllSpeciesResponse.Name = speciesentity.Name;
            getAllSpeciesResponse.CreatedDate = speciesentity.CreatedDate;

            getAllSpeciesResponses.Add(getAllSpeciesResponse);
        }
        return getAllSpeciesResponses;
    }

    public UpdatedSpeciesResponse Update(UpdateSpeciesRequest updateRequest)
    {
        Species species = new();
        species.Id = updateRequest.Id;
        species.Name = updateRequest.Name;
        
        _speciesDal.Update(species);

        UpdatedSpeciesResponse updatedSpeciesResponse = new UpdatedSpeciesResponse();
        updatedSpeciesResponse.Id = species.Id;
        updatedSpeciesResponse.Name = species.Name;
        updatedSpeciesResponse.UpdatedDate = species.UpdatedDate;
        return updatedSpeciesResponse;
    }
}
