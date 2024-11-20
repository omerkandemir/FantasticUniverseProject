using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetAbilityCharacterResponse : IGetResponse
{
    public int AbilityId { get; set; }
    public int CharacterId { get; set; }
}
