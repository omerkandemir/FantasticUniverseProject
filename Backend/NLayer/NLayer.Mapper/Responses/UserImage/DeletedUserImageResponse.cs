using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.UserImage;

public class DeletedUserImageResponse : IDeletedResponse
{
    public int Id { get; set; }
}
