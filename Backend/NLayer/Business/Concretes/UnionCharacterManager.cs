using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Dto.Requests.UnionCharacter;
using NLayer.Dto.Responses.UnionCharacter;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class UnionCharacterManager : IUnionCharacterService
{
    private readonly IUnionCharacterDal _unionCharacterDal;
    public UnionCharacterManager(IUnionCharacterDal unionCharacterDal)
    {
        _unionCharacterDal = unionCharacterDal;
    }
    public CreatedUnionCharacterResponse Add(CreateUnionCharacterRequest createRequest)
    {
        UnionCharacter unionCharacter = new();
        unionCharacter.UnionId = createRequest.UnionId;
        unionCharacter.CharacterId = createRequest.CharacterId;

        _unionCharacterDal.Add(unionCharacter);

        CreatedUnionCharacterResponse createdUnionCharacterResponse = new CreatedUnionCharacterResponse();
        createdUnionCharacterResponse.Id = unionCharacter.Id;
        createdUnionCharacterResponse.UnionId = unionCharacter.UnionId;
        createdUnionCharacterResponse.CharacterId = unionCharacter.CharacterId;
        createdUnionCharacterResponse.CreatedDate = unionCharacter.CreatedDate;

        return createdUnionCharacterResponse;
    }

    public DeletedUnionCharacterResponse Delete(DeleteUnionCharacterRequest deleteRequest)
    {
        UnionCharacter unionCharacter = new() { Id = deleteRequest.Id };
        _unionCharacterDal.Delete(unionCharacter);
        DeletedUnionCharacterResponse deletedUnionCharacterResponse = new DeletedUnionCharacterResponse();
        deletedUnionCharacterResponse.Id = unionCharacter.Id;
        return deletedUnionCharacterResponse;
    }

    public GetAllUnionCharacterResponse Get(int id)
    {
        GetAllUnionCharacterResponse getAllUnionCharacterResponse = new GetAllUnionCharacterResponse();
        UnionCharacter unionCharacter = _unionCharacterDal.Get(x => x.Id == id);
        getAllUnionCharacterResponse.Id = unionCharacter.Id;
        getAllUnionCharacterResponse.UnionId = unionCharacter.UnionId;
        getAllUnionCharacterResponse.CharacterId = unionCharacter.CharacterId;
        getAllUnionCharacterResponse.CreatedDate = unionCharacter.CreatedDate;
        return getAllUnionCharacterResponse;
    }

    public List<GetAllUnionCharacterResponse> GetAll()
    {
        List<UnionCharacter> unionCharacters = _unionCharacterDal.GetAll();

        List<GetAllUnionCharacterResponse> getAllUnionCharacterResponses = new List<GetAllUnionCharacterResponse>();

        foreach (var unionCharacter in unionCharacters)
        {
            GetAllUnionCharacterResponse getAllUnionCharacterResponse = new GetAllUnionCharacterResponse();
            getAllUnionCharacterResponse.Id = unionCharacter.Id;
            getAllUnionCharacterResponse.UnionId = unionCharacter.UnionId;
            getAllUnionCharacterResponse.CharacterId = unionCharacter.CharacterId;

            getAllUnionCharacterResponses.Add(getAllUnionCharacterResponse);
        }
        return getAllUnionCharacterResponses;
    }

    public UpdatedUnionCharacterResponse Update(UpdateUnionCharacterRequest updateRequest)
    {
        UnionCharacter unionCharacter = new();
        unionCharacter.Id = updateRequest.Id;
        unionCharacter.UnionId = updateRequest.UnionId;
        unionCharacter.CharacterId = updateRequest.CharacterId;

        _unionCharacterDal.Update(unionCharacter);

        UpdatedUnionCharacterResponse updatedUnionCharacterResponse = new UpdatedUnionCharacterResponse();
        updatedUnionCharacterResponse.Id = updatedUnionCharacterResponse.Id;
        updatedUnionCharacterResponse.UnionId = updatedUnionCharacterResponse.UnionId;
        updatedUnionCharacterResponse.CharacterId = updatedUnionCharacterResponse.CharacterId;
        updatedUnionCharacterResponse.UpdatedDate = updatedUnionCharacterResponse.UpdatedDate;
        return updatedUnionCharacterResponse;
    }
}
