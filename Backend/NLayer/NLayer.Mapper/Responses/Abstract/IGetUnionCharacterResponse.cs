using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetUnionCharacterResponse : IGetResponse
{
    public int UnionId { get; set; }
    public int CharacterId { get; set; }
}
