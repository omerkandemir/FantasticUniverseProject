using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.UserImage;

public class UpdateUserImageRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int UniverseImageId { get; set; }
}
