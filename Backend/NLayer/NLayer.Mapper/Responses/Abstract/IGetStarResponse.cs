using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetStarResponse : IGetResponse
{
    public int GalaxyId { get; set; }
    public string Name { get; set; }
}
