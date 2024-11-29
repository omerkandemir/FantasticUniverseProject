using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.AbilityCharacter;

public class GetAllAbilityCharacterResponse : IGetAllResponse<IGetAbilityCharacterResponse>
{
    public ICollection<IGetAbilityCharacterResponse>? Responses { get; set; }
}
