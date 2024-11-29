using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Abstract;

public interface IGetUserImageResponse : IGetResponse
{
    public int UserId { get; set; }
    public int UniverseImageId { get; set; }
}
