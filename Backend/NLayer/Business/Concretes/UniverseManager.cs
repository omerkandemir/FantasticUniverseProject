using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.DataAccess.Concretes.EntityFramework;
using NLayer.Dto.Requests.Universe;
using NLayer.Dto.Responses.Character;
using NLayer.Dto.Responses.Universe;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class UniverseManager : IUniverseService
{
    private readonly IUniverseDal _universeDal;
    public UniverseManager(IUniverseDal universeDal)
    {
        _universeDal = universeDal;
    }
    public CreatedUniverseResponse Add(CreateUniverseRequest createRequest)
    {
        Universe universe = new();
        universe.Name = createRequest.Name;

        _universeDal.Add(universe);

        CreatedUniverseResponse createdUniverseResponse = new CreatedUniverseResponse();
        createdUniverseResponse.Id = universe.Id;
        createdUniverseResponse.Name = universe.Name;
        createdUniverseResponse.CreatedDate = universe.CreatedDate;

        return createdUniverseResponse;
    }

    public DeletedUniverseResponse Delete(DeleteUniverseRequest deleteRequest)
    {
        Universe universe = new() { Id = deleteRequest.Id };
        _universeDal.Delete(universe);
        DeletedUniverseResponse deletedUniverseResponse = new DeletedUniverseResponse();
        deletedUniverseResponse.Id = universe.Id;
        return deletedUniverseResponse;
    }

    public GetAllUniverseResponse Get(int id)
    {
        GetAllUniverseResponse getAllUniverseResponse = new GetAllUniverseResponse();
        Universe universe = _universeDal.Get(x => x.Id == id);
        getAllUniverseResponse.Id = universe.Id;
        getAllUniverseResponse.Name = universe.Name;
        getAllUniverseResponse.CreatedDate = universe.CreatedDate;
        return getAllUniverseResponse;
    }

    public List<GetAllUniverseResponse> GetAll()
    {
        List<Universe> universes = _universeDal.GetAll();

        List<GetAllUniverseResponse> getAllUniverseResponses = new List<GetAllUniverseResponse>();

        foreach (var universe in universes)
        {
            GetAllUniverseResponse getAllUniverseResponse = new GetAllUniverseResponse();
            getAllUniverseResponse.Id = universe.Id;
            getAllUniverseResponse.Name = universe.Name;
            getAllUniverseResponse.CreatedDate = universe.CreatedDate;

            getAllUniverseResponses.Add(getAllUniverseResponse);
        }
        return getAllUniverseResponses;
    }

    public UpdatedUniverseResponse Update(UpdateUniverseRequest updateRequest)
    {
        Universe universe = new();
        universe.Id = updateRequest.Id;
        universe.Name = updateRequest.Name;

        _universeDal.Update(universe);

        UpdatedUniverseResponse updatedUniverseResponse = new UpdatedUniverseResponse();
        updatedUniverseResponse.Id = universe.Id;
        updatedUniverseResponse.Name = universe.Name;
        updatedUniverseResponse.UpdatedDate = universe.UpdatedDate;
        return updatedUniverseResponse;
    }
}
