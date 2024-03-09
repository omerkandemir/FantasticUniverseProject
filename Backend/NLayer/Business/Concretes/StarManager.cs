using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Dto.Requests.Star;
using NLayer.Dto.Responses.Star;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class StarManager : IStarService
{
    private readonly IStarDal _starDal;
    public StarManager(IStarDal starDal)
    {
        _starDal = starDal;
    }
    public CreatedStarResponse Add(CreateStarRequest createRequest)
    {
        Star star = new();
        star.GalaxyId = createRequest.GalaxyId;
        star.Name = createRequest.Name;
        
        _starDal.Add(star);

        CreatedStarResponse createdStarResponse = new CreatedStarResponse();
        createdStarResponse.Id = star.Id;
        createdStarResponse.GalaxyId = star.GalaxyId;
        createdStarResponse.Name = star.Name;
        createdStarResponse.CreatedDate = star.CreatedDate;

        return createdStarResponse;
    }

    public DeletedStarResponse Delete(DeleteStarRequest deleteRequest)
    {
        Star star = new() { Id = deleteRequest.Id };
        _starDal.Delete(star);
        DeletedStarResponse deletedStarResponse = new DeletedStarResponse();
        deletedStarResponse.Id = star.Id;
        return deletedStarResponse;
    }

    public GetAllStarResponse Get(int id)
    {
        GetAllStarResponse getAllStarResponse = new GetAllStarResponse();
        Star star = _starDal.Get(x => x.Id == id);
        getAllStarResponse.Id = star.Id;
        getAllStarResponse.GalaxyId = star.GalaxyId;
        getAllStarResponse.Name = star.Name;
        getAllStarResponse.CreatedDate = star.CreatedDate;
        return getAllStarResponse;
    }

    public List<GetAllStarResponse> GetAll()
    {
        List<Star> stars = _starDal.GetAll();

        List<GetAllStarResponse> getAllStarResponses = new List<GetAllStarResponse>();

        foreach (var star in stars)
        {
            GetAllStarResponse getAllStarResponse = new GetAllStarResponse();
            getAllStarResponse.Id = star.Id;
            getAllStarResponse.GalaxyId = star.GalaxyId;
            getAllStarResponse.Name = star.Name;
            getAllStarResponse.CreatedDate = star.CreatedDate;

            getAllStarResponses.Add(getAllStarResponse);
        }
        return getAllStarResponses;
    }

    public UpdatedStarResponse Update(UpdateStarRequest updateRequest)
    {
        Star star = new();
        star.Id = updateRequest.Id;
        star.GalaxyId = updateRequest.GalaxyId;
        star.Name = updateRequest.Name;

        _starDal.Update(star);

        UpdatedStarResponse updatedStarResponse = new UpdatedStarResponse();
        updatedStarResponse.Id = star.Id;
        updatedStarResponse.GalaxyId = star.GalaxyId;
        updatedStarResponse.Name = star.Name;
        updatedStarResponse.UpdatedDate = star.UpdatedDate;
        return updatedStarResponse;
    }
}
