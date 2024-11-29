using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.UserImage;

public class GetUserImageResponse : IGetUserImageResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UserId { get; set; }
    public int UniverseImageId { get; set; }
}
