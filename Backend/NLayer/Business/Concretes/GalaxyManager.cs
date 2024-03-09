using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Dto.Requests.Galaxy;
using NLayer.Dto.Responses.Galaxy;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class GalaxyManager : IGalaxyService
{
    private readonly IGalaxyDal _galaxyDal;
    public GalaxyManager(IGalaxyDal galaxyDal)
    {
        _galaxyDal = galaxyDal;
    }
    public CreatedGalaxyResponse Add(CreateGalaxyRequest createRequest)
    {
        Galaxy galaxy = new();
        galaxy.UniverseId = createRequest.UniverseId;
        galaxy.Name = createRequest.Name;

        _galaxyDal.Add(galaxy);

        CreatedGalaxyResponse createGalaxyResponse = new CreatedGalaxyResponse();
        createGalaxyResponse.Id = galaxy.Id;
        createGalaxyResponse.UniverseId = galaxy.UniverseId;
        createGalaxyResponse.Name = galaxy.Name;
        createGalaxyResponse.CreatedDate = galaxy.CreatedDate;

        return createGalaxyResponse;
    }

    public DeletedGalaxyResponse Delete(DeleteGalaxyRequest deleteRequest)
    {
        Galaxy galaxy = new() { Id = deleteRequest.Id };
        _galaxyDal.Delete(galaxy);
        DeletedGalaxyResponse deletedGalaxyResponse = new DeletedGalaxyResponse();
        deletedGalaxyResponse.Id = galaxy.Id;
        return deletedGalaxyResponse;
    }

    public GetAllGalaxyResponse Get(int id)
    {
        GetAllGalaxyResponse getAllGalaxyResponse = new GetAllGalaxyResponse();
        Galaxy galaxy = _galaxyDal.Get(x => x.Id == id);
        getAllGalaxyResponse.Id = galaxy.Id;
        getAllGalaxyResponse.UniverseId = galaxy.UniverseId;
        getAllGalaxyResponse.Name = galaxy.Name;
        getAllGalaxyResponse.CreatedDate = galaxy.CreatedDate;
        return getAllGalaxyResponse;
    }

    public List<GetAllGalaxyResponse> GetAll()
    {
        List<Galaxy> galaxies = _galaxyDal.GetAll();

        List<GetAllGalaxyResponse> getAllGalaxyResponses = new List<GetAllGalaxyResponse>();

        foreach (var galaxy in galaxies)
        {
            GetAllGalaxyResponse getAllGalaxyResponse = new GetAllGalaxyResponse();
            getAllGalaxyResponse.Id = galaxy.Id;
            getAllGalaxyResponse.UniverseId = galaxy.UniverseId;
            getAllGalaxyResponse.Name = galaxy.Name;
            getAllGalaxyResponse.CreatedDate = galaxy.CreatedDate;

            getAllGalaxyResponses.Add(getAllGalaxyResponse);
        }
        return getAllGalaxyResponses;
    }

    public UpdatedGalaxyResponse Update(UpdateGalaxyRequest updateRequest)
    {
        Galaxy galaxy = new();
        galaxy.Id = updateRequest.Id;
        galaxy.UniverseId = updateRequest.UniverseId;
        galaxy.Name = updateRequest.Name;

        _galaxyDal.Update(galaxy);

        UpdatedGalaxyResponse updatedGalaxyResponse = new UpdatedGalaxyResponse();
        updatedGalaxyResponse.Id = galaxy.Id;
        updatedGalaxyResponse.UniverseId = galaxy.UniverseId;
        updatedGalaxyResponse.Name = galaxy.Name;
        updatedGalaxyResponse.UpdatedDate = galaxy.UpdatedDate;
        return updatedGalaxyResponse;
    }
}
