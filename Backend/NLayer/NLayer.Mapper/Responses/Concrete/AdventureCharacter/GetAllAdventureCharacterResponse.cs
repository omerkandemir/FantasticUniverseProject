using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.AdventureCharacter;

public class GetAllAdventureCharacterResponse : IGetAllResponse<IGetAdventureCharacterResponse>
{
    public ICollection<IGetAdventureCharacterResponse>? Responses { get; set; }
}
