using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetSpeciesResponse : IGetResponse
{
    public string Name { get; set; }
}
