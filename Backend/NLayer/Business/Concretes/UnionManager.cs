using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.DataAccess.Concretes.EntityFramework;
using NLayer.Dto.Requests.Union;
using NLayer.Dto.Responses.Character;
using NLayer.Dto.Responses.Union;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

//Eğer veri yoksa ilk eklenen veriyi UnionLeader yapmayı düşün
public class UnionManager : IUnionService
{
    private readonly IUnionDal _unionDal;
    public UnionManager(IUnionDal unionDal)
    {
        _unionDal = unionDal;
    }
    public CreatedUnionResponse Add(CreateUnionRequest createRequest)
    {
        Union union = new();
        union.Name = createRequest.Name;
        union.Target = createRequest.Target;
        union.UnionLeaderId = createRequest.UnionLeaderId;
        union.UniverseId = createRequest.UniverseId;

        _unionDal.Add(union);

        CreatedUnionResponse createdUnionResponse = new CreatedUnionResponse();
        createdUnionResponse.Id = union.Id;
        createdUnionResponse.Name = union.Name;
        createdUnionResponse.Target = union.Target;
        createdUnionResponse.UnionLeaderId = union.UnionLeaderId;
        createdUnionResponse.UniverseId = union.UniverseId;
        createdUnionResponse.CreatedDate = union.CreatedDate;

        return createdUnionResponse;
    }

    public DeletedUnionResponse Delete(DeleteUnionRequest deleteRequest)
    {
        Union union = new() { Id = deleteRequest.Id };
        _unionDal.Delete(union);
        DeletedUnionResponse deletedUnionResponse = new DeletedUnionResponse();
        deletedUnionResponse.Id = union.Id;
        return deletedUnionResponse;
    }

    public GetAllUnionResponse Get(int id)
    {
        GetAllUnionResponse getAllUnionResponse = new GetAllUnionResponse();
        Union union = _unionDal.Get(x => x.Id == id);
        getAllUnionResponse.Id = union.Id;
        getAllUnionResponse.Name = union.Name;
        getAllUnionResponse.Target = union.Target;
        getAllUnionResponse.UnionLeaderId = union.UnionLeaderId;
        getAllUnionResponse.UniverseId = union.UniverseId;
        getAllUnionResponse.CreatedDate = union.CreatedDate;
        return getAllUnionResponse;
    }

    public List<GetAllUnionResponse> GetAll()
    {
        List<Union> unions = _unionDal.GetAll();

        List<GetAllUnionResponse> getAllUnionResponses = new List<GetAllUnionResponse>();

        foreach (var union in unions)
        {
            GetAllUnionResponse getAllUnionResponse = new GetAllUnionResponse();
            getAllUnionResponse.Id = union.Id;
            getAllUnionResponse.Name = union.Name;
            getAllUnionResponse.Target = union.Target;
            getAllUnionResponse.UnionLeaderId = union.UnionLeaderId;
            getAllUnionResponse.UniverseId = union.UniverseId;
            getAllUnionResponse.CreatedDate = union.CreatedDate;

            getAllUnionResponses.Add(getAllUnionResponse);
        }
        return getAllUnionResponses;
    }

    public UpdatedUnionResponse Update(UpdateUnionRequest updateRequest)
    {
        Union union = new();
        union.Id = updateRequest.Id;
        union.Name = updateRequest.Name;
        union.Target = updateRequest.Target;
        union.UnionLeaderId = updateRequest.UnionLeaderId;
        union.UniverseId = updateRequest.UniverseId;

        _unionDal.Update(union);

        UpdatedUnionResponse updatedUnionResponse = new UpdatedUnionResponse();
        updatedUnionResponse.Id = union.Id;
        updatedUnionResponse.Name = union.Name;
        updatedUnionResponse.Target = union.Target;
        updatedUnionResponse.UnionLeaderId = union.UnionLeaderId;
        updatedUnionResponse.UniverseId = union.UniverseId;
        updatedUnionResponse.UpdatedDate = union.UpdatedDate;
        return updatedUnionResponse;
    }
}
