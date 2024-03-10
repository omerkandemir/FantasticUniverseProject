using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Dto.Requests.AbilityCharacter;
using NLayer.Dto.Responses.AbilityCharacter;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class AbilityCharacterManager : IAbilityCharacterService
{
    IAbilityCharacterDal _abilityCharacterDal;
    public AbilityCharacterManager(IAbilityCharacterDal abilityCharacterDal)
    {
        _abilityCharacterDal = abilityCharacterDal;
    }
    public CreatedAbilityCharacterResponse Add(CreateAbilityCharacterRequest createRequest)
    {
        AbilityCharacter abilitycharacter = new();
        abilitycharacter.AbilityId = createRequest.AbilityId;
        abilitycharacter.CharacterId = createRequest.CharacterId;

        _abilityCharacterDal.Add(abilitycharacter);

        CreatedAbilityCharacterResponse createAbilityCharacterResponse = new CreatedAbilityCharacterResponse();
        createAbilityCharacterResponse.Id = abilitycharacter.Id;
        createAbilityCharacterResponse.AbilityId = abilitycharacter.AbilityId;
        createAbilityCharacterResponse.CharacterId = abilitycharacter.CharacterId;
        createAbilityCharacterResponse.CreatedDate = abilitycharacter.CreatedDate;

        return createAbilityCharacterResponse;
    }

    public DeletedAbilityCharacterResponse Delete(DeleteAbilityCharacterRequest deleteRequest)
    {
        AbilityCharacter abilityCharacter = new() { Id = deleteRequest.Id };
        _abilityCharacterDal.Delete(abilityCharacter);
        DeletedAbilityCharacterResponse deletedAbilityCharacterResponse = new DeletedAbilityCharacterResponse();
        deletedAbilityCharacterResponse.Id = abilityCharacter.Id;
        return deletedAbilityCharacterResponse;
    }

    public GetAllAbilityCharacterResponse Get(int id)
    {
        GetAllAbilityCharacterResponse getAllAbilityCharacterResponse = new GetAllAbilityCharacterResponse();
        AbilityCharacter abilityCharacter = _abilityCharacterDal.Get(x => x.Id == id);
        getAllAbilityCharacterResponse.Id = abilityCharacter.Id;
        getAllAbilityCharacterResponse.AbilityId = abilityCharacter.AbilityId;
        getAllAbilityCharacterResponse.CharacterId = abilityCharacter.CharacterId;
        getAllAbilityCharacterResponse.CreatedDate = abilityCharacter.CreatedDate;
        return getAllAbilityCharacterResponse;
    }

    public List<GetAllAbilityCharacterResponse> GetAll()
    {
        List<AbilityCharacter> abilityCharacters = _abilityCharacterDal.GetAll();

        List<GetAllAbilityCharacterResponse> getAllAbilityCharacterResponses = new List<GetAllAbilityCharacterResponse>();

        foreach (var abilityCharacter in abilityCharacters)
        {
            GetAllAbilityCharacterResponse getAllAbilityCharacterResponse = new GetAllAbilityCharacterResponse();
            getAllAbilityCharacterResponse.Id = abilityCharacter.Id;
            getAllAbilityCharacterResponse.AbilityId = abilityCharacter.AbilityId;
            getAllAbilityCharacterResponse.CharacterId = abilityCharacter.CharacterId;
            getAllAbilityCharacterResponse.CreatedDate = abilityCharacter.CreatedDate;

            getAllAbilityCharacterResponses.Add(getAllAbilityCharacterResponse);
        }
        return getAllAbilityCharacterResponses;
    }

    public UpdatedAbilityCharacterResponse Update(UpdateAbilityCharacterRequest updateRequest)
    {
        AbilityCharacter abilityCharacter = new();
        abilityCharacter.Id = updateRequest.Id;
        abilityCharacter.AbilityId = updateRequest.AbilityId;
        abilityCharacter.CharacterId = updateRequest.CharacterId;

        _abilityCharacterDal.Update(abilityCharacter);

        UpdatedAbilityCharacterResponse updatedAbilityCharacterResponse = new UpdatedAbilityCharacterResponse();
        updatedAbilityCharacterResponse.Id = abilityCharacter.Id;
        updatedAbilityCharacterResponse.AbilityId = abilityCharacter.AbilityId;
        updatedAbilityCharacterResponse.CharacterId = abilityCharacter.CharacterId;
        updatedAbilityCharacterResponse.UpdatedDate = abilityCharacter.UpdatedDate;
        return updatedAbilityCharacterResponse;
    }
}
