using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.UserImage;

public class CreateUserImageRequest : ICreateRequest
{
    public int UserId { get; set; }
    public int UniverseImageId { get; set; }
}
