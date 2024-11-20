using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Character;

public class GetAllCharacterResponse : IGetAllResponse<IGetCharacterResponse>
{
    public ICollection<IGetCharacterResponse>? Responses { get; set; }
}
