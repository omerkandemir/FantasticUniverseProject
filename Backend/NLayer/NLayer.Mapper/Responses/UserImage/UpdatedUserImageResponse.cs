using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.UserImage;

public class UpdatedUserImageResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int UserId { get; set; }
    public int UniverseImageId { get; set; }
}
