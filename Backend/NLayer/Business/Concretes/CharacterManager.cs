using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Character;
using NLayer.Dto.Responses.Character;

namespace NLayer.Business.Concretes;

public class CharacterManager : ICharacterService
{
    public CreatedCharacterResponse Add(CreateCharacterRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public DeletedCharacterResponse Delete(DeleteCharacterRequest deleteRequest)
    {
        throw new NotImplementedException();
    }

    public GetAllCharacterResponse Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<GetAllCharacterResponse> GetAll()
    {
        throw new NotImplementedException();
    }

    public UpdatedCharacterResponse Update(UpdateCharacterRequest updateRequest)
    {
        throw new NotImplementedException();
    }
}
