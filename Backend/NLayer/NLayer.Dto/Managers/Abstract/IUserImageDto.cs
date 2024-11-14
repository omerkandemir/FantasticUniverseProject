using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.UserImage;
using NLayer.Mapper.Responses.UniverseImage;
using NLayer.Mapper.Responses.UserImage;

namespace NLayer.Dto.Managers.Abstract;

public interface IUserImageDto : IEntityRepositoryAsyncDto<
    CreateUserImageRequest,
    UpdateUserImageRequest,
    DeleteUserImageRequest,
    GetAllUserImageResponse>
{
    Task AddUserFirstImages();
    Task<List<GetAllUniverseImageResponse>> GetUsersImage();
}
