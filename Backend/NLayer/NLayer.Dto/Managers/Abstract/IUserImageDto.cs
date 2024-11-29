using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.UserImage;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.UserImage;

namespace NLayer.Dto.Managers.Abstract;

public interface IUserImageDto : IEntityRepositoryAsyncDto<
    IGetUserImageResponse,
    CreateUserImageRequest,
    UpdateUserImageRequest,
    DeleteUserImageRequest,
    GetUserImageResponse,
    GetAllUserImageResponse>
{
    Task AddUserFirstImages();
    Task<IGetAllResponse<IGetUniverseImageResponse>> GetUsersImage();
}
