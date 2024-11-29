using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.UnionCharacter;

public class GetAllUnionCharacterResponse : IGetAllResponse<IGetUnionCharacterResponse>
{
    public ICollection<IGetUnionCharacterResponse>? Responses { get; set; }
}
