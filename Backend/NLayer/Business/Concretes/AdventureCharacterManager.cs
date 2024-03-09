using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Dto.Requests.AdventureCharacter;
using NLayer.Dto.Responses.AdventureCharacter;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class AdventureCharacterManager : IAdventureCharacterService
{
    IAdventureCharacterDal _adventureCharacterDal;
    public AdventureCharacterManager(IAdventureCharacterDal adventureCharacterDal)
    {
        _adventureCharacterDal = adventureCharacterDal;
    }
    public CreatedAdventureCharacterResponse Add(CreateAdventureCharacterRequest createRequest)
    {
        AdventureCharacter adventureCharacter = new();
        adventureCharacter.AdventureId = createRequest.AdventureId;
        adventureCharacter.CharacterId = createRequest.CharacterId;

        _adventureCharacterDal.Add(adventureCharacter);

        CreatedAdventureCharacterResponse createdAdventureCharacterResponse = new CreatedAdventureCharacterResponse();
        createdAdventureCharacterResponse.Id = adventureCharacter.Id;
        createdAdventureCharacterResponse.AdventureId = adventureCharacter.AdventureId;
        createdAdventureCharacterResponse.CharacterId = adventureCharacter.CharacterId;
        createdAdventureCharacterResponse.CreatedDate = adventureCharacter.CreatedDate;

        return createdAdventureCharacterResponse;
    }

    public DeletedAdventureCharacterResponse Delete(DeleteAdventureCharacterRequest deleteRequest)
    {
        AdventureCharacter adventureCharacter = new() { Id = deleteRequest.Id };
        _adventureCharacterDal.Delete(adventureCharacter);
        DeletedAdventureCharacterResponse deletedAdventureCharacterResponse = new DeletedAdventureCharacterResponse();
        deletedAdventureCharacterResponse.Id = adventureCharacter.Id;
        return deletedAdventureCharacterResponse;
    }

    public GetAllAdventureCharacterResponse Get(int id)
    {
        GetAllAdventureCharacterResponse getAllAdventureCharacterResponse = new GetAllAdventureCharacterResponse();
        AdventureCharacter adventureCharacter = _adventureCharacterDal.Get(x => x.Id == id);
        getAllAdventureCharacterResponse.Id = adventureCharacter.Id;
        getAllAdventureCharacterResponse.AdventureId = adventureCharacter.AdventureId;
        getAllAdventureCharacterResponse.CharacterId = adventureCharacter.CharacterId;
        getAllAdventureCharacterResponse.CreatedDate = adventureCharacter.CreatedDate;
        return getAllAdventureCharacterResponse;
    }

    public List<GetAllAdventureCharacterResponse> GetAll()
    {
        List<AdventureCharacter> adventureCharacters = _adventureCharacterDal.GetAll();

        List<GetAllAdventureCharacterResponse> getAllAdventureCharacterResponses = new List<GetAllAdventureCharacterResponse>();

        foreach (var adventureCharacter in adventureCharacters)
        {
            GetAllAdventureCharacterResponse getAllAdventureCharacterResponse = new GetAllAdventureCharacterResponse();
            getAllAdventureCharacterResponse.Id = adventureCharacter.Id;
            getAllAdventureCharacterResponse.CharacterId = adventureCharacter.CharacterId;
            getAllAdventureCharacterResponse.AdventureId = adventureCharacter.AdventureId;
            getAllAdventureCharacterResponse.CreatedDate = adventureCharacter.CreatedDate;

            getAllAdventureCharacterResponses.Add(getAllAdventureCharacterResponse);
        }
        return getAllAdventureCharacterResponses;
    }

    public UpdatedAdventureCharacterResponse Update(UpdateAdventureCharacterRequest updateRequest)
    {
        AdventureCharacter adventureCharacter = new();
        adventureCharacter.Id = updateRequest.Id;
        adventureCharacter.AdventureId = updateRequest.AdventureId;
        adventureCharacter.CharacterId = updateRequest.CharacterId;

        _adventureCharacterDal.Update(adventureCharacter);

        UpdatedAdventureCharacterResponse updatedAdventureCharacterResponse = new UpdatedAdventureCharacterResponse();
        updatedAdventureCharacterResponse.Id = adventureCharacter.Id;
        updatedAdventureCharacterResponse.AdventureId = adventureCharacter.AdventureId;
        updatedAdventureCharacterResponse.CharacterId = adventureCharacter.CharacterId;
        updatedAdventureCharacterResponse.UpdatedDate = adventureCharacter.UpdatedDate;
        return updatedAdventureCharacterResponse;
    }
}
