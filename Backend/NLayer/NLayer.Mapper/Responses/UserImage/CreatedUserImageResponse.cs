using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.UserImage;

public class CreatedUserImageResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UserId { get; set; }
    public int UniverseImageId { get; set; }

}
