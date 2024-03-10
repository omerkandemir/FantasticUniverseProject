using NLayer.Business.Abstracts;
using NLayer.DataAccess.Abstracts;
using NLayer.Dto.Requests.Character;
using NLayer.Dto.Responses.Character;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes;

public class CharacterManager : ICharacterService
{
    private readonly ICharacterDal _characterDal;
    public CharacterManager(ICharacterDal characterDal)
    {
        _characterDal = characterDal;
    }
    public CreatedCharacterResponse Add(CreateCharacterRequest createRequest)
    {
        Character character = new();
        character.SpeciesId = createRequest.SpeciesId;
        character.Name = createRequest.Name;
        character.BirthDate = createRequest.BirthDate;
        character.DeathDate = createRequest.DeathDate;
        character.MasterCharacterId = createRequest.MasterCharacterId;
        character.ApprenticeId = createRequest.ApprenticeId;

        _characterDal.Add(character);

        CreatedCharacterResponse createCharacterResponse = new CreatedCharacterResponse();
        createCharacterResponse.Id = character.Id;
        createCharacterResponse.SpeciesId = character.SpeciesId;
        createCharacterResponse.Name = character.Name;
        createCharacterResponse.BirthDate = character.BirthDate;
        createCharacterResponse.DeathDate = character.DeathDate;
        createCharacterResponse.MasterCharacterId = character.MasterCharacterId;
        createCharacterResponse.ApprenticeId = character.ApprenticeId;
        createCharacterResponse.CreatedDate = character.CreatedDate;

        return createCharacterResponse;
    }

    public DeletedCharacterResponse Delete(DeleteCharacterRequest deleteRequest)
    {
        Character character = new() { Id = deleteRequest.Id };
        _characterDal.Delete(character);
        DeletedCharacterResponse deletedCharacterResponse = new DeletedCharacterResponse();
        deletedCharacterResponse.Id = character.Id;
        return deletedCharacterResponse;
    }

    public GetAllCharacterResponse Get(int id)
    {
        GetAllCharacterResponse getAllCharacterResponse = new GetAllCharacterResponse();
        Character character = _characterDal.Get(x => x.Id == id);
        getAllCharacterResponse.Id = character.Id;
        getAllCharacterResponse.SpeciesId = character.SpeciesId;
        getAllCharacterResponse.Name = character.Name;
        getAllCharacterResponse.BirthDate = character.BirthDate;
        getAllCharacterResponse.DeathDate = character.DeathDate;
        getAllCharacterResponse.MasterCharacterId = character.MasterCharacterId;
        getAllCharacterResponse.ApprenticeId = character.ApprenticeId;
        getAllCharacterResponse.CreatedDate = character.CreatedDate;
        return getAllCharacterResponse;
    }

    public List<GetAllCharacterResponse> GetAll()
    {
        List<Character> characters = _characterDal.GetAll();

        List<GetAllCharacterResponse> getAllCharacterResponses = new List<GetAllCharacterResponse>();

        foreach (var character in characters)
        {
            GetAllCharacterResponse getAllCharacterResponse = new GetAllCharacterResponse();
            getAllCharacterResponse.Id = character.Id;
            getAllCharacterResponse.SpeciesId = character.SpeciesId;
            getAllCharacterResponse.Name = character.Name;
            getAllCharacterResponse.BirthDate = character.BirthDate;
            getAllCharacterResponse.DeathDate = character.DeathDate;
            getAllCharacterResponse.MasterCharacterId = character.MasterCharacterId;
            getAllCharacterResponse.ApprenticeId = character.ApprenticeId;
            getAllCharacterResponse.CreatedDate = character.CreatedDate;

            getAllCharacterResponses.Add(getAllCharacterResponse);
        }
        return getAllCharacterResponses;
    }

    public UpdatedCharacterResponse Update(UpdateCharacterRequest updateRequest)
    {
        Character character = new();
        character.Id = updateRequest.Id;
        character.SpeciesId = updateRequest.SpeciesId;
        character.Name = updateRequest.Name;
        character.BirthDate = updateRequest.BirthDate;
        character.DeathDate = updateRequest.DeathDate;
        character.MasterCharacterId = updateRequest.MasterCharacterId;
        character.ApprenticeId = updateRequest.ApprenticeId;

        _characterDal.Update(character);

        UpdatedCharacterResponse updatedCharacterResponse = new UpdatedCharacterResponse();
        updatedCharacterResponse.Id = character.Id;
        updatedCharacterResponse.SpeciesId = character.SpeciesId;
        updatedCharacterResponse.Name = character.Name;
        updatedCharacterResponse.BirthDate = character.BirthDate;
        updatedCharacterResponse.DeathDate = character.DeathDate;
        updatedCharacterResponse.MasterCharacterId = character.MasterCharacterId;
        updatedCharacterResponse.ApprenticeId = character.ApprenticeId;
        updatedCharacterResponse.UpdatedDate = character.UpdatedDate;
        return updatedCharacterResponse;
    }
}
