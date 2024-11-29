using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.UserImage;

public class GetAllUserImageResponse : IGetAllResponse<IGetUserImageResponse>
{
    public ICollection<IGetUserImageResponse>? Responses { get; set; }
}
