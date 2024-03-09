using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.UnionCharacter;
using NLayer.Dto.Responses.UnionCharacter;

namespace NLayer.Business.Concretes;

public class UnionCharacterManager : IUnionCharacterService
{
    public UnionCharacterManager()
    {
        
    }
    public CreatedUnionCharacterResponse Add(CreateUnionCharacterRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public DeletedUnionCharacterResponse Delete(DeleteUnionCharacterRequest deleteRequest)
    {
        throw new NotImplementedException();
    }

    public GetAllUnionCharacterResponse Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<GetAllUnionCharacterResponse> GetAll()
    {
        throw new NotImplementedException();
    }

    public UpdatedUnionCharacterResponse Update(UpdateUnionCharacterRequest updateRequest)
    {
        throw new NotImplementedException();
    }
}
