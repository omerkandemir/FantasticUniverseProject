using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.UserImage;

public class DeleteUserImageRequest : IDeleteRequest
{
    public int Id { get; set; }
}
