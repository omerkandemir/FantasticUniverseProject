using NLayer.Business.Abstracts;
using NLayer.Dto.Requests.Union;
using NLayer.Dto.Responses.Union;

namespace NLayer.Business.Concretes;

//Eğer veri yoksa ilk eklenen veriyi UnionLeader yapmayı düşün
public class UnionManager : IUnionService
{
    public CreatedUnionResponse Add(CreateUnionRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public DeletedUnionResponse Delete(DeleteUnionRequest deleteRequest)
    {
        throw new NotImplementedException();
    }

    public GetAllUnionResponse Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<GetAllUnionResponse> GetAll()
    {
        throw new NotImplementedException();
    }

    public UpdatedUnionResponse Update(UpdateUnionRequest updateRequest)
    {
        throw new NotImplementedException();
    }
}
