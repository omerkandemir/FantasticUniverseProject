using NLayer.Core.Dto.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetUniverseResponse : IGetResponse
{
    public string Name { get; set; }
    public ThemeSetting ThemeSetting { get; set; }
}