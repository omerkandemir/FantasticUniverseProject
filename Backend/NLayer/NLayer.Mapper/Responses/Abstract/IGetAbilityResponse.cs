using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetAbilityResponse : IGetResponse
{
    public string Name { get; set; }
}
